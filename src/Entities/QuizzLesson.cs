namespace web_back.Entities
{
    public class QuizzLesson
    {
        private QuizzLesson() { }
        public QuizzLesson(string question, List<String> answers, int correctAnswerIndex, string explain, int index)
        {
            Question = question;
            Answers = answers;
            CorrectAnswerIndex = correctAnswerIndex;
            Explain = explain;
            Index = index;

        }

        public long Id { get; set; }
        public string Question { get; set; }
        public List<String> Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public string Explain { get; set; }
        public string ImgURL { get; set; }
        public int Index { get; set; }
    }
}
