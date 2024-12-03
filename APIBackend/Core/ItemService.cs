using APIBackend.DBModels;
using APIBackend.DTOModels;
using APIBackend.Interface;
using Azure.Core;
using System.Text.RegularExpressions;

namespace APIBackend.Core
{
    public class ItemService : IItemService
    {
        private readonly IDomainService _domainService;
        private readonly IFileService _fileservice;
        private readonly Regex rgx = new Regex("[^a-zA-Z0-9 -]");
        private readonly GeneralService _generalservice;

        public ItemService(IDomainService domainService, GeneralService generalservice, IFileService fileservice)
        {
            _domainService = domainService;
            _generalservice = generalservice;
            _fileservice = fileservice;
        }

        public async Task<LoadItemResponse> LoadItemList()
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new LoadItemResponse();

                    var query = from a in _domainService.GetAllItems()
                                join cate in _domainService.GetAllItemsCategories() on a.Category equals cate.Id into cat
                                from b in cat.DefaultIfEmpty()
                                select new LoadItemResponseData
                                {
                                    Id = a.Id,
                                    Name = a.ItemName ?? string.Empty,
                                    Price = (decimal)a.Price,
                                    Stock = a.Stock,
                                    Category = b != null ?  b.CategoryName : string.Empty,
                                    Image = a.ImageUrl ?? string.Empty
                                };

                    result.Multiform = query.ToList();

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Method: LoadItemList(), Message: {ex.Message}");
                }
            }).ConfigureAwait(false);
        }

        public async Task<LoadItemResponseData> LoadItemDetail(string id)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new LoadItemResponseData();

                    var query = from a in _domainService.GetAllItems()
                                where a.Id == id
                                select new LoadItemResponseData
                                {
                                    Id = a.Id,
                                    Name = a.ItemName ?? string.Empty,
                                    Price = (decimal)a.Price,
                                    Stock = a.Stock,
                                    Category = a.Category,
                                    Image = a.ImageUrl ?? string.Empty,
                                };

                    result = query.First();

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Method: LoadItemDetail(), Message: {ex.Message}");
                }
            }).ConfigureAwait(false);
        }

        public async Task<ResultBase> SaveItem(SaveItemParam request)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    var result = new ResultBase()
                    {
                        Success = false
                    };

                    var transaction = _domainService.BeginTransaction();
                    string newImageName = string.Empty;
                    DateTime now = DateTime.Now;

                    if (request.image != null)
                    {
                        string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
                        newImageName = await _fileservice.SaveFile(request.image, allowedFileExtentions);
                    }

                    var itemChk = _domainService.GetAllItems().OrderByDescending(x => x.Id).FirstOrDefault();
                    var userID = _domainService.GetAllUsers().Where(x => x.Username == request.user_id).First().Id;

                    var newItem = new TbItem
                    {
                        Id = _generalservice.IDGenerator(itemChk != null ? itemChk.Id : string.Empty),
                        ItemName = request.name,
                        Stock = request.stock != null ? (int)request.stock : AppConstant.index,
                        Price = request.price != null ? (int)request.price : AppConstant.index,
                        Category = request.category != null ? request.category : string.Empty,
                        UserAdd = userID,
                        UserEdit = userID,
                        DateAdd = now,
                        DateEdit = now
                    };

                    if (!string.IsNullOrEmpty(newImageName))
                    {
                        newItem.ImageUrl = newImageName;
                    }

                    _domainService.InsertItem(newItem);
                    result.Success = true;
                    result.Message = MessageConstants.S_SUCCESSFULLY;
                    result.code = (int)HTTPCode.OK;

                    _domainService.SaveChanges();
                    transaction.Commit();

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Method: SaveItem(), Message: {ex.Message}");
                }
            }).ConfigureAwait(false);
        }

        public async Task<ResultBase> UpdateItem(SaveItemParam request)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    var result = new ResultBase()
                    {
                        Success = false
                    };

                    var itemChk = _domainService.GetAllItems().Where(x => x.Id == request.Id).FirstOrDefault();

                    if (itemChk != null)
                    {
                        var transaction = _domainService.BeginTransaction();
                        string newImageName = string.Empty;
                        string? oldImage = itemChk.ImageUrl;

                        if (request.image != null)
                        {
                            string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
                            newImageName = await _fileservice.SaveFile(request.image, allowedFileExtentions);
                        }

                        var userID = _domainService.GetAllUsers().Where(x => x.Username == request.user_id).First().Id;

                        itemChk.ItemName = request.name != null ? request.name : itemChk.ItemName;
                        itemChk.Stock = request.stock != null ? (int)request.stock : itemChk.Stock;
                        itemChk.Price = request.price != null ? (int)request.price : itemChk.Price;
                        itemChk.Category = request.category != null ? request.category : itemChk.Category;
                        itemChk.UserEdit = userID;
                        itemChk.DateEdit = DateTime.Now;

                        if (!string.IsNullOrEmpty(newImageName))
                        {
                            if (!string.IsNullOrEmpty(oldImage))
                            {
                                _fileservice.DeleteFile(oldImage);
                            }

                            itemChk.ImageUrl = newImageName;
                        }

                        _domainService.UpdateItem(itemChk);

                        result.Success = true;
                        result.Message = MessageConstants.S_SUCCESSFULLY;
                        result.code = (int)HTTPCode.OK;

                        _domainService.SaveChanges();
                        transaction.Commit();
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
                    throw new Exception($"Method: UpdateItem(), Message: {ex.Message}");
                }
            }).ConfigureAwait(false);
        }

        public async Task<ResultBase> DeleteItem(string id)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new ResultBase()
                    {
                        Success = false
                    };

                    var itemChk = _domainService.GetAllItems().Where(x => x.Id == id).FirstOrDefault();

                    if (itemChk != null)
                    {
                        if (!string.IsNullOrEmpty(itemChk.ImageUrl))
                        {
                            _fileservice.DeleteFile(itemChk.ImageUrl);
                        }

                        var transaction = _domainService.BeginTransaction();

                        _domainService.DeleteItem(itemChk);
                        result.code = (int)HTTPCode.OK;
                        result.Success = true;

                        _domainService.SaveChanges();
                        transaction.Commit();
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
                    throw new Exception($"Method: DeleteItem(), Message: {ex.Message}");
                }
            }).ConfigureAwait(false);
        }

        public async Task<LoadItemCategoryResponse> LoadItemCategory()
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new LoadItemCategoryResponse();

                    var query = from a in _domainService.GetAllItemsCategories()
                                select new LoadItemCategoryResponseData
                                {
                                    Id = a.Id,
                                    Name = a.CategoryName ?? string.Empty
                                };

                    result.Multiform = query.ToList();

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Method: LoadItemCategory(), Message: {ex.Message}");
                }
            }).ConfigureAwait(false);
        }

        public async Task<LoadItemResponse> LoadItemStock()
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new LoadItemResponse();

                    var query = from a in _domainService.GetAllItems()
                                join cate in _domainService.GetAllItemsCategories() on a.Category equals cate.Id into cat
                                from b in cat.DefaultIfEmpty()
                                select new LoadItemResponseData
                                {
                                    Id = a.Id,
                                    Name = a.ItemName ?? string.Empty,
                                    Price = (decimal)a.Price,
                                    Stock = a.Stock,
                                    Category = b != null ? b.CategoryName : string.Empty
                                };

                    result.Multiform = query.ToList();

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Method: LoadItemStock(), Message: {ex.Message}");
                }
            }).ConfigureAwait(false);
        }
    }
}
