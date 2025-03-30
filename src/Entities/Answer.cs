namespace web_back.Entities
{
    public class Answer
    {
        public Answer() { }
        public Answer(int index, string content)
        {
            this.Content = content;
            this.Index = index;
        }

        public long Id { get; set; }
        private int Index { get; set; }
        private string Content { get; set; }
    }
}
