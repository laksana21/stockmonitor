using Microsoft.EntityFrameworkCore.Storage;
using APIBackend.DBModels;

namespace APIBackend.Interface
{
    public interface IDomainService
    {
        IQueryable<TbUser> GetAllUsers();
        IQueryable<TbSession> GetAllSessions();
        IQueryable<TbItem> GetAllItems();
        IQueryable<TbItemCategory> GetAllItemsCategories();
        IQueryable<TbTransaction> GetAllTransactions();

        string InsertSession(TbSession models);
        void UpdateSession(TbSession models);
        void DeleteSession(TbSession models);
        string InsertItem(TbItem models);
        void UpdateItem(TbItem models);
        void DeleteItem(TbItem models);

        string InsertTransaction(TbTransaction models);
        void UpdateTransaction(TbTransaction models);

        IDbContextTransaction BeginTransaction();
        void SaveChanges();
    }
}
