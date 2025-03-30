namespace web_back.Entities
{
    public class VideoLesson
    {
        public VideoLesson() { }
        public VideoLesson(string videoUrl,string videoId)
        {
            VideoURL = videoUrl;
            VideoId = videoId;
        }

        public long Id { get; set; }
        public string VideoURL { get; set; }
        public string VideoId { get; set; }
    }
}
