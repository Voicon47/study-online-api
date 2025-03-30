using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_back.Data;
using web_back.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_back.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public HomeController(DataContext context)
        {
            this._dataContext = context;
        }
        // GET: api/<HomeController>
        [HttpGet]
        public async Task<ActionResult> GetHome()
        {
            var size = 10;
            var typeCourses = await _dataContext.CategoriesCourse.ToListAsync();
            var homeResponse = new HomeResponse();
            var courseResList = new List<CourseResponse>();

            foreach (var type in typeCourses)
            {
                var courseRes = new CourseResponse();
                var courses = await GetCourseByType(type, size);
                courseRes.CategoryCourse = type;
                courseRes.Courses = courses;
                courseResList.Add(courseRes);
            }

            var banners = _dataContext.Banners.ToListAsync();

            homeResponse.CourseRes = courseResList;
            homeResponse.CategoriesCourse = typeCourses;
            homeResponse.Banners = banners.Result;

            return Ok(homeResponse);
        }

        private async Task<List<Course>> GetCourseByType(CategoryCourse categoryCourse, int size)
        {
            var courses = await _dataContext.Courses
                .Include(course => course.CategoryCourse)
                .Where(course => course.CategoryCourse.CategoryName == categoryCourse.CategoryName)
                .Take(size)
                .ToListAsync();

            return courses;
        }


    

    // GET api/<HomeController>/5
    [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
