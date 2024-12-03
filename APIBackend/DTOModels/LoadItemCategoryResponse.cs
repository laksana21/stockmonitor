namespace APIBackend.DTOModels
{
    public class LoadItemCategoryResponse
    {
        public List<LoadItemCategoryResponseData> Multiform { get; set; }
    }

    public class LoadItemCategoryResponseData
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
