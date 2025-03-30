namespace web_back.Data
{
    public class IPaginationRequestDto<T>
    {
        public T? Where { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
