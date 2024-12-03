namespace APIBackend.DTOModels
{
    public class SaveItemRequest
    {
        public string? name { get; set; }
        public decimal? price { get; set; }
        public int? stock { get; set; }
        public string? category { get; set; }
        public IFormFile? image { get; set; }
    }

    public class SaveItemParam
    {
        public string Id { get; set; }
        public string user_id { get; set; }
        public string? name { get; set; }
        public decimal? price { get; set; }
        public int? stock { get; set; }
        public string? category { get; set; }
        public IFormFile? image { get; set; }
    }
}
