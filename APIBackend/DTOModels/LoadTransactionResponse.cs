namespace APIBackend.DTOModels
{
    public class LoadTransactionResponse
    {
        public List<LoadTransactionResponseData> Multiform { get; set; }
    }

    public class LoadTransactionResponseData
    {
        public string Id { get; set; }
        public string User_id { get; set; }
        public string Item { get; set; }
        public decimal Price { get; set; }
        public int Pcs { get; set; }
        public decimal Total { get; set; }
    }
}
