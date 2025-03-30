namespace web_back.Entities
{
    public class CategoryCourse
    {
        public CategoryCourse()
        {
            this.CategoryName = string.Empty;
        }
        public CategoryCourse(string typeName, bool? isLock, bool? isAdd)
        {
            this.CategoryName = typeName;
            this.IsLock = isLock;
            this.IsAdd = isAdd;
        }

        public CategoryCourse(long id, string typeName)
        {
            this.Id = id;
            this.CategoryName = typeName;
            
        }

        public long Id { get; set; }
        public string CategoryName { get; set; }
        public bool? IsLock { get; set; }
        public bool? IsAdd { get; set;}
    }
}
