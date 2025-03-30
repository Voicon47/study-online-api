using web_back.Entities;

namespace web_back.Data
{
    public class CourseQueryDto
    {
        public int? CategoryId { get; set; }
        public Status? Status { get; set; }
        public string? Query { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
