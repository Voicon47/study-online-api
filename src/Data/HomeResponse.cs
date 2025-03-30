using web_back.Entities;

namespace web_back.Data
{
    public class HomeResponse
    {
        public HomeResponse()
        {
        }

        public HomeResponse(List<CourseResponse> courseRes, List<CategoryCourse> categoriesCourse)
        {
            CourseRes = courseRes;
            CategoriesCourse = categoriesCourse;
        }


        public List<CourseResponse> CourseRes { get; set; }
        public List<CategoryCourse> CategoriesCourse { get; set; }
        public List<Banner> Banners { get; set; }
    }
}
