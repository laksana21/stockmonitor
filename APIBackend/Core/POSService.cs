using APIBackend.DBModels;
using APIBackend.DTOModels;
using APIBackend.Interface;

namespace APIBackend.Core
{
    public class POSService : IPOSService
    {
        private readonly IDomainService _domainService;
        private readonly GeneralService _generalservice;

        public POSService(IDomainService domainService, GeneralService generalservice)
        {
            _domainService = domainService;
            _generalservice = generalservice;
        }

        public async Task<ResultBase> SaveTransaction(SaveTransactionParam request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new ResultBase()
                    {
                        Success = false
                    };

                    var stockChk = _domainService.GetAllItems().Where(x => x.Id == request.Item_id).FirstOrDefault();

                    if (stockChk != null)
                    {
                        if (stockChk.Stock >= request.Pcs)
                        {
                            var transaction = _domainService.BeginTransaction();
                            DateTime now = DateTime.Now;
                            var transactChk = _domainService.GetAllTransactions().OrderByDescending(x => x.Id).FirstOrDefault();
                            var userID = _domainService.GetAllUsers().Where(x => x.Username == request.User_id).First().Id;

                            stockChk.Stock = stockChk.Stock - request.Pcs;

                            var newTransact = new TbTransaction
                            {
                                Id = _generalservice.IDGenerator(transactChk != null ? transactChk.Id : string.Empty),
                                Item = request.Item_id,
                                Pcs = request.Pcs,
                                Price = (decimal)stockChk.Price,
                                UserId = userID,
                                TransactionDate = DateOnly.FromDateTime(now),
                                TransactionTime = TimeOnly.FromDateTime(now)
                            };

                            _domainService.InsertTransaction(newTransact);
                            _domainService.UpdateItem(stockChk);

                            result.Success = true;
                            result.Message = MessageConstants.S_SUCCESSFULLY;
                            result.code = (int)HTTPCode.OK;

                            _domainService.SaveChanges();
                            transaction.Commit();
                        }
                        else
                        {
                            result.code = (int)HTTPCode.Accepted;
                            result.Message = MessageConstants.S_OUT_OF_STOCK;
                        }
                    }
                    else
                    {
                        result.code = (int)HTTPCode.Not_Found;
                        result.Message = MessageConstants.S_DATA_NOT_FOUND;
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Method: SaveTransaction(), Message: {ex.Message}");
                }
            }).ConfigureAwait(false);
        }

        public async Task<LoadTransactionResponse> LoadTransaction()
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new LoadTransactionResponse();

                    var query = from a in _domainService.GetAllTransactions()
                                join item in _domainService.GetAllItems() on a.Item equals item.Id into it
                                from b in it.DefaultIfEmpty()
                                select new LoadTransactionResponseData
                                {
                                    Id = a.Id,
                                    Item = b.ItemName,
                                    Price = (decimal)a.Price,
                                    Pcs = a.Pcs,
                                    Total = a.Price * a.Pcs
                                };

                    result.Multiform = query.ToList();

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Method: LoadTransaction(), Message: {ex.Message}");
                }
            }).ConfigureAwait(false);
        }

        public async Task<LoadTransactionReportResponse> LoadReportTransaction()
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new LoadTransactionReportResponse();

                    var query = from a in _domainService.GetAllTransactions()
                                join item in _domainService.GetAllItems() on a.Item equals item.Id into it
                                from b in it.DefaultIfEmpty()
                                join cate in _domainService.GetAllItemsCategories() on b.Category equals cate.Id into cat
                                from c in cat.DefaultIfEmpty()
                                select new
                                {
                                    Transact_date = a.TransactionDate,
                                    Item = b.ItemName,
                                    Category = c.CategoryName,
                                    Price = (decimal)a.Price,
                                    Pcs = a.Pcs,
                                    Total = a.Price * a.Pcs
                                };

                    var lasq = (query.ToList()).GroupBy(x => x.Transact_date).Select(g => new LoadTransactionReportResponseData
                    {
                        Transact_date = g.Key,
                        Item = (g.GroupBy(x => x.Item).Select(x => new LoadTransactionReportItem
                        {
                            Item = x.Key,
                            Pcs = x.Sum(y => y.Pcs)
                        })).ToList(),
                        Category = (g.GroupBy(x => x.Category).Select(x => new LoadTransactionReportCategory
                        {
                            Category = x.Key,
                            Pcs = x.Sum(y => y.Pcs)
                        })).ToList(),
                        Total_pcs = g.Sum(x => x.Pcs),
                        Total = g.Sum(x => x.Total)
                    });

                    result.Multiform = lasq.ToList();

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Method: LoadTransaction(), Message: {ex.Message}");
                }
            }).ConfigureAwait(false);
        }
    }
}
