namespace APIBackend.DTOModels
{
    public class LoadTransactionRequest
    {
        public string Id { get; set; }
    }

    public class SaveTransactionRequest
    {
        public string Item_id { get; set; }
        public int Pcs { get; set; }
    }

    public class SaveTransactionParam
    {
        public string Id { get; set; }
        public string User_id { get; set; }
        public string Item_id { get; set; }
        public int Pcs { get; set; }
    }
}
