using Microsoft.Extensions.Hosting;

namespace web_back.Entities
{
    public class PostLesson
    {
        public PostLesson() { }
        public PostLesson(SubItemPost post)
        {
            SubItemPost = post;
        }

        public long Id { get; set; }
        public SubItemPost SubItemPost { get; set; }
    }
}
