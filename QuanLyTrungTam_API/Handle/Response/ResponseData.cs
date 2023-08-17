using QuanLyTrungTam_API.Enums;

namespace QuanLyTrungTam_API.Handle.Response
{
    public class ResponseData<T>
    {
        public ActionStatus Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<T>? DataList { get; set; }
    }
}
