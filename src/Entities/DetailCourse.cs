namespace web_back.Entities
{
    public class DetailCourse
    {
        public DetailCourse(List<GroupLesson> groupLessons)
        {
            GroupLessons = groupLessons;
        }

        public DetailCourse(TypeLesson type, List<GroupLesson> groupLessons)
        {
            Type = type;
            GroupLessons = groupLessons;
        }

        public long Id { get; set; }
        public TypeLesson Type;
        public List<GroupLesson> GroupLessons;
    }
}
