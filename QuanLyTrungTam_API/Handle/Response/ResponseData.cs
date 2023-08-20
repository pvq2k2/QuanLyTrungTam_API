namespace QuanLyTrungTam_API.Handle.Response
{
    public class ResponseData<T>
    {
        public int Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
