namespace APIBackend.DTOModels
{
    public class LoadUserRequest
    {
        public string username { get; set; }
        public string token { get; set; }
    }

    public class LoadLoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
