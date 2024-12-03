namespace APIBackend.Interface
{
    public interface IFileService
    {
        Task<string> SaveFile(IFormFile imageFile, string[] allowedFileExtensions);

        void DeleteFile(string filename);
    }
}
