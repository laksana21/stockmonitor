namespace APIBackend.DTOModels
{
    public class LoadTransactionReportResponse
    {
        public List<LoadTransactionReportResponseData> Multiform { get; set; }
    }

    public class LoadTransactionReportResponseData
    {
        public DateOnly Transact_date { get; set;}
        public List<LoadTransactionReportCategory> Category { get; set;}
        public List<LoadTransactionReportItem> Item { get; set;}
        public int Total_pcs { get; set;}
        public decimal Total { get; set;}
    }

    public class LoadTransactionReportCategory
    {
        public string Category { get; set; }
        public int Pcs { get; set;}
    }

    public class LoadTransactionReportItem
    {
        public string Item { get; set; }
        public int Pcs { get; set; }
    }
}
