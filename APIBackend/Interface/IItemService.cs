using APIBackend.DTOModels;

namespace APIBackend.Interface
{
    public interface IItemService
    {
        Task<LoadItemResponse> LoadItemList();
        Task<LoadItemResponseData> LoadItemDetail(string id);
        Task<ResultBase> SaveItem(SaveItemParam request);
        Task<ResultBase> UpdateItem(SaveItemParam request);
        Task<ResultBase> DeleteItem(string id);
        Task<LoadItemCategoryResponse> LoadItemCategory();
        Task<LoadItemResponse> LoadItemStock();
    }
}
