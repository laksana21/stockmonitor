using APIBackend.DTOModels;

namespace APIBackend.Interface
{
    public interface IPOSFacade
    {
        Task<ResultBase> SaveTransaction(LoadUserRequest auth, SaveTransactionRequest request);
        Task<ResultBase<LoadTransactionResponse>> LoadTransaction(LoadUserRequest auth);
        Task<ResultBase<LoadTransactionReportResponse>> LoadReportTransaction(LoadUserRequest auth);
    }
}
