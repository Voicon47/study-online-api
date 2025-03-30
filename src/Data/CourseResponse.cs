using web_back.Entities;

namespace web_back.Data
{
    public class CourseResponse
    {
        public CourseResponse()
        {
        }

        public CourseResponse(CategoryCourse categoryCourse, List<Course> courses)
        {
            CategoryCourse = categoryCourse;
            Courses = courses;
        }

        public CourseResponse(CategoryCourse categoryCourse, List<Course> courses, int size, int page)
        {
            CategoryCourse = categoryCourse;
            Courses = courses;
            Size = size;
            Page = page;
        }

        public CategoryCourse CategoryCourse { get; set; }
        public List<Course> Courses { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
    }
}
