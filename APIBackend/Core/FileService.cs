using APIBackend.Interface;
using Microsoft.Extensions.Hosting;
using System;

namespace APIBackend.Core
{
    public class FileService : IFileService
    {
        IWebHostEnvironment _webhostenv;

        public FileService(IWebHostEnvironment webhostenv)
        {
            _webhostenv = webhostenv;
        }

        public async Task<string> SaveFile(IFormFile imageFile, string[] allowedFileExtensions)
        {
            if (imageFile == null)
            {
                throw new ArgumentNullException(nameof(imageFile));
            }

            var contentPath = _webhostenv.ContentRootPath;
            var path = Path.Combine(contentPath, "Upload");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var ext = Path.GetExtension(imageFile.FileName);
            if (!allowedFileExtensions.Contains(ext))
            {
                throw new ArgumentException($"Only {string.Join(",", allowedFileExtensions)} are allowed.");
            }

            var fileName = $"{Guid.NewGuid().ToString()}{ext}";
            var fileNameWithPath = Path.Combine(path, fileName);
            using var stream = new FileStream(fileNameWithPath, FileMode.Create);
            await imageFile.CopyToAsync(stream);

            return fileName;
        }

        public void DeleteFile(string fileNameWithExtension)
        {
            if (string.IsNullOrEmpty(fileNameWithExtension))
            {
                throw new ArgumentNullException(nameof(fileNameWithExtension));
            }
            var contentPath = _webhostenv.ContentRootPath;
            var path = Path.Combine(contentPath, $"Upload", fileNameWithExtension);

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Invalid file path");
            }
            File.Delete(path);
        }
    }
}
