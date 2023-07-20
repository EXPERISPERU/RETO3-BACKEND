namespace backend.services
{
    public class ApiResponse<T>
    {
        public bool success { get; set; }
        public string errMsj { get; set; }
        public T data { get; set; }
    }
}
