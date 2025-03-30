﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_back.Data;
using web_back.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_back.Controllers
{
    [Route("api/category-course")]
    [ApiController]
    public class CategoryCourseController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoryCourseController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryCourse>>> GetCategoriesCourse()
        {
            var typeCourses = await _context.CategoriesCourse
                .ToListAsync();
            return Ok(typeCourses);
        }

        // GET: api/type-course/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryCourse>> GetCourse(int id)
        {
            var course = await _context.CategoriesCourse.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // POST: api/course
        [HttpPost]
        public async Task<ActionResult<CategoryCourse>> CreateTypeCourse(CategoryCourse categoryCourse)
        {
            _context.CategoriesCourse.Add(categoryCourse);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourse), new { id = categoryCourse.Id }, categoryCourse);
        }

        // PUT: api/type-course/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, CategoryCourse updatedCategoryCourse)
        {
            if (id != updatedCategoryCourse.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedCategoryCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeCourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(id);
        }

        // DELETE: api/course/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeCourse(int id)
        {
            var typeCourse = await _context.CategoriesCourse.FindAsync(id);

            if (typeCourse == null)
            {
                return NotFound();
            }

            _context.CategoriesCourse.Remove(typeCourse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeCourseExists(int id)
        {
            return _context.CategoriesCourse.Any(e => e.Id == id);
        }

    }
}
