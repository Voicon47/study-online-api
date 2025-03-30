using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using web_back.Data;
using web_back.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_back.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly DataContext _context;

        public CourseController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetCourses()
        {
            var groupedCourses = await _context.Courses
                .Include(course => course.CategoryCourse)
                .GroupBy(course => course.CategoryCourse.CategoryName)
                .ToListAsync();

            var coursesGroupedByType = groupedCourses
                .SelectMany(group => group.Take(3))
                .ToList();


            return Ok(coursesGroupedByType);
        }

        // GET: api/course/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(long id)
        {
            //var course = await _context.Courses.FindAsync(id);
            var course = await _context.Courses
            .Include(c => c.CategoryCourse) // Assuming CategoryCourse is a related entity
            .Include(c => c.GroupLessons)
            .FirstOrDefaultAsync(c => c.Id == id);
            

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // POST: api/course
        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse([FromBody] Course course)
        {
            var categoryCourse = await _context.CategoriesCourse.FindAsync(course.CategoryCourse.Id);
            if(categoryCourse == null)
            {
                return NotFound();
            }
            course.CategoryCourse = categoryCourse;
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
        }

        // PUT: api/course/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Course>> UpdateCourse(int id, Course updatedCourse)
        {
            if (id != updatedCourse.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(updatedCourse);
        }

        // DELETE: api/course/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(long id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("banner/{id}")]
        public async Task<IActionResult> Deletebanner(long id)
        {
            var course = await _context.Banners.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            _context.Banners.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
        [HttpGet("get-user-course/{userId}/{courseId}")]
        public async Task<ActionResult<UserCourse>> UserCourse(int userId, int courseId)
        {
            var userCourses = await _context.UserCourses
                .Where(uc => uc.User.Id == userId && uc.Course.Id == courseId)
                .Include(uc => uc.Course) // Assuming UserCourse has a navigation property to Course
                .Include(uc => uc.User)
                .ToListAsync();

            if (!userCourses.Any())
            {
                return NotFound($"No courses found for user with ID {userId}");
            }

            return Ok(userCourses);
        }

        [HttpGet("check-user-course-exits/{userId}/{courseId}")]
        public async Task<bool> UserCourseExist(int userId,int courseId)
        {
            var check = await _context.UserCourses
                .AnyAsync(uc => uc.User.Id == userId && uc.Course.Id == courseId);
            return check;
        }
        [HttpPost("pagination")]
        public async Task<ActionResult<IPaginationResponseDto<Course>>> GetPaginatedCoursesAsync(IPaginationRequestDto<CourseQueryDto> queryData)
        {
            var queryDto = queryData.Where;
            if (queryDto == null) return NotFound();
            //queryDto.Status = queryDto.Status == Status.ComingSoon ? Status.Published :
            //                   queryDto.Status == Status.UnPublished ? Status.ComingSoon :
            //                    (Status?)null;
            // Fetch filtered courses from the database based on `queryData`
            var allCourses = await _context.Courses
                 .Include(c => c.CategoryCourse)
                 .Where(c => queryDto.CategoryId == null || c.CategoryCourse.Id == queryDto.CategoryId)
                 .Where(c => !queryDto.Status.HasValue || c.Status == queryDto.Status)
                 .Where(c => string.IsNullOrEmpty(queryDto.Query)
                             || c.Title.Contains(queryDto.Query)
                             || c.Description.Contains(queryDto.Query))
                 .ToListAsync();
            if (allCourses == null) return NotFound();
            
            var paginatedResult = await PaginateAsync(allCourses, queryData.PageNumber, queryData.PageSize);

            return Ok(paginatedResult);

        }
        private async Task<IPaginationResponseDto<Course>> PaginateAsync(List<Course> courses, int page, int pageSize)
        {
            var totalItems = courses.Count;
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            //if (totalItems <= 4) page = 1;
            var items = courses.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new IPaginationResponseDto<Course>
            {
                Data = items,
                TotalItems = totalItems,
                PageSize = pageSize,
                PageNumber = page
            };
        }
        [HttpPost("count")]
        public async Task<ActionResult<int>> PostCount(CourseQueryDto queryData)
        {
            //queryData.Status = queryData.Status == Status.Published ? Status.Published :
            //                   queryData.Status == Status.ComingSoon ? Status.ComingSoon :
            //                    (Status?)null;
            //Fetch filtered courses from the database based on `queryData`
            var allCourses = await _context.Courses
                .Include(c => c.CategoryCourse)
                .Where(c => queryData.CategoryId == null || c.CategoryCourse.Id == queryData.CategoryId)
                .Where(c => !queryData.Status.HasValue || c.Status == queryData.Status)
                .Where(c => string.IsNullOrEmpty(queryData.Query)
                            || c.Title.Contains(queryData.Query)
                            || c.Description.Contains(queryData.Query))
                .ToListAsync();
            return Ok(allCourses.Count);
            //return Ok(queryData.Status.ToString());

        }
        private async Task<List<Course>> GetCourseByType(CategoryCourse categoryCourse)
        {
            var courses = await _context.Courses
                .Include(course => course.CategoryCourse)
                .Where(course => course.CategoryCourse.CategoryName == categoryCourse.CategoryName)
                .ToListAsync();

            return courses;
        }
        [HttpDelete("delete-all-group")]
        public async Task<IActionResult> DeleteGroupLesson()
        {
            var allGroupLessons = await _context.GroupLessons.ToListAsync();

            if (!allGroupLessons.Any())
            {
                return NoContent(); // No items to delete
            }

            _context.GroupLessons.RemoveRange(allGroupLessons);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("get-all-group-lesson")]
        public async Task<ActionResult> GetAllGroupLesson()
        {
            var groupLesson = _context.GroupLessons;

            return Ok(groupLesson);
        }
        [HttpGet("get-group-lesson-exist/{id}")]
        public async Task<ActionResult<GroupLesson>> GetGroupLesson(long id)
        {
            var groupLesson = await _context.GroupLessons.FindAsync(id);

            if (groupLesson == null)
            {
                return NotFound();
            }

            return Ok(groupLesson);
        }
        [HttpPost("add-group-lesson/{courseId}")]
        public async Task<ActionResult<Course>> AddGroupLesson(long courseId,GroupLesson newGroupLesson)
        {
           if (courseId == 0|| newGroupLesson == null) return BadRequest();
            var course = await _context.Courses.FindAsync(courseId);
            if (course == null) return NotFound();

            try
            {
                course.GroupLessons?.Add(newGroupLesson);
                _context.GroupLessons.Add(newGroupLesson);
                await _context.SaveChangesAsync();
                //return course;

                return CreatedAtAction(nameof(GetGroupLesson), new { id = newGroupLesson.Id }, newGroupLesson);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while creating the group lesson.");
            }

        }
        


    }
}
