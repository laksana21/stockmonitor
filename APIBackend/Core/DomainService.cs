using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using APIBackend.DBModels;
using APIBackend.Interface;
using EFCore.BulkExtensions;

namespace APIBackend.Core
{
    public partial class DomainService : IDomainService
    {
        private readonly DataContext _dataContext;

        public DomainService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<TbItem> GetAllItems()
        {
            return _dataContext.TbItems;
        }

        public IQueryable<TbItemCategory> GetAllItemsCategories()
        {
            return _dataContext.TbItemCategories;
        }

        public IQueryable<TbSession> GetAllSessions()
        {
            return _dataContext.TbSessions;
        }

        public IQueryable<TbTransaction> GetAllTransactions()
        {
            return _dataContext.TbTransactions;
        }

        public IQueryable<TbUser> GetAllUsers()
        {
            return _dataContext.TbUsers;
        }

        public string InsertItem(TbItem models)
        {
            var strId = string.Join("-", new string[] { models.Id, models.ItemName });

            try
            {
                _dataContext.TbItems.Add(models);

                return strId;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException($"Method: InsertItem(), Item: {strId}, Message: {ex.Message}");
            }
        }

        public string InsertSession(TbSession models)
        {
            var strId = models.UserId;

            try
            {
                _dataContext.TbSessions.Add(models);

                return strId;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException($"Method: InsertSession(), UserId: {strId}, Message: {ex.Message}");
            }
        }

        public string InsertTransaction(TbTransaction models)
        {
            var strId = models.Id;

            try
            {
                _dataContext.TbTransactions.Add(models);

                return strId;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException($"Method: InsertTransaction(), TransactId: {strId}, Message: {ex.Message}");
            }
        }

        public void UpdateItem(TbItem models)
        {
            var strId = string.Join("-", new string[] { models.Id, models.ItemName });

            try
            {
                _dataContext.TbItems.Update(models);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException($"Method: UpdateItem(), Item: {strId}, Message: {ex.Message}");
            }
        }

        public void UpdateSession(TbSession models)
        {
            var strId = models.UserId;

            try
            {
                _dataContext.TbSessions.Update(models);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException($"Method: UpdateSession(), Item: {strId}, Message: {ex.Message}");
            }
        }

        public void UpdateTransaction(TbTransaction models)
        {
            var strId = models.Id;

            try
            {
                _dataContext.TbTransactions.Update(models);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException($"Method: UpdateTransaction(), Item: {strId}, Message: {ex.Message}");
            }
        }

        public void DeleteSession(TbSession models)
        {
            var strId = models.UserId;

            try
            {
                _dataContext.Remove(models);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException($"Method: DeleteSession(), Item: {strId}, Message: {ex.Message}");
            }
        }

        public void DeleteItem(TbItem models)
        {
            var strId = models.Id;

            try
            {
                _dataContext.Remove(models);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException($"Method: DeleteItem(), Item: {strId}, Message: {ex.Message}");
            }
        }

        public IDbContextTransaction BeginTransaction()
        {
            try
            {
                IDbContextTransaction transaction = _dataContext.Database.BeginTransaction(IsolationLevel.Serializable);

                return transaction;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException($"Method: BeginTransaction(), Message: {ex.Message}");
            }
        }

        public void SaveChanges()
        {
            try
            {
                _dataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException($"Method: SaveChanges(), Message: {ex.Message}");
            }
        }
    }
}
