using APIBackend.DTOModels;

namespace APIBackend.Interface
{
    public interface IItemFacade
    {
        Task<ResultBase<LoadItemResponse>> LoadItemList(LoadUserRequest auth);
        Task<ResultBase<LoadItemResponseData>> LoadItemDetail(LoadUserRequest auth, string id);
        Task<ResultBase> SaveItem(LoadUserRequest auth, SaveItemRequest request);
        Task<ResultBase> UpdateItem(LoadUserRequest auth, string id, SaveItemRequest request);
        Task<ResultBase> DeleteItem(LoadUserRequest auth, string id);
        Task<ResultBase<LoadItemCategoryResponse>> LoadItemCategory(LoadUserRequest auth);
        Task<ResultBase<LoadItemResponse>> LoadItemStock(LoadUserRequest auth);
    }
}
