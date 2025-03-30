namespace web_back.Entities
{
    public class GroupLesson
    {
        public GroupLesson() { }
        public GroupLesson(string? title, List<Lesson>? lessons)
        {
            Title = title;
            Lessons = lessons;
        }

        public long Id { get; set; }
        public string? Title { get; set; }
        private List<Lesson>? Lessons { get; set; }
        public long TotalLesson => Lessons?.Count ?? 0;
        public int Index { get; set; }
    }
}
