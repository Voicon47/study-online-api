namespace web_back.Entities
{
    public class UserCourse
    {

        public UserCourse() { }
        public UserCourse(User user,Course course,GroupLesson groupLesson) 
        {
            User = user;
            Course = course;
            CurrentGroupLesson = groupLesson;
        }
        public long Id { get; set; }
        public User User { get; set; }
        public Course Course { get; set; }
        //public Boolean IsPayment {  get; set; }
        public List<Lesson> LessonPassed { get; set; }
        public Lesson? CurrentLesson { get; set; }
        public GroupLesson? CurrentGroupLesson { get; set; }
        public PaymentHistory? PaymentHistory { get; set; }
        public DateTime RegisterAt { get; set; }
        
    }
}
