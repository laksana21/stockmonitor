namespace APIBackend.DTOModels
{
    public class LoadItemResponse
    {
        public List<LoadItemResponseData> Multiform { get; set; }
    }

    public class LoadItemResponseData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
