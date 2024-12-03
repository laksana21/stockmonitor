using APIBackend.DTOModels;

namespace APIBackend.Interface
{
    public interface IPOSService
    {
        Task<ResultBase> SaveTransaction(SaveTransactionParam request);
        Task<LoadTransactionResponse> LoadTransaction();
        Task<LoadTransactionReportResponse> LoadReportTransaction();
    }
}
