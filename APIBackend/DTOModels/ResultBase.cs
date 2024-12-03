namespace APIBackend.DTOModels
{
    public class ResultBase
    {
        public int code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class ResultBase<T>
    {
        public int code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Model { get; set; }
    }
}
