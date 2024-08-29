using Azure.Storage.Blobs;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using Microsoft.EntityFrameworkCore;

namespace DDVTracker
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(IFormFile file, string objectType, string fileName);
    }

    public class LocalFileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocalFileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> SaveFileAsync(IFormFile file, string objectType, string fileName)
        {
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", objectType, fileName);

            using (var memoryStream = new MemoryStream())
            {
                using (var image = Image.Load(file.OpenReadStream()))
                {
                    image.Save(memoryStream, new WebpEncoder());
                }
                memoryStream.Position = 0;

                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await memoryStream.CopyToAsync(fileStream);
                }
            }

            return $"/images/{objectType}/{fileName}";
        }
    }

    public class AzureBlobStorageService : IFileStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName;

        public AzureBlobStorageService(IConfiguration configuration)
        {
            _blobServiceClient = new BlobServiceClient(configuration["AzureBlobStorage:ConnectionString"]);
            _containerName = configuration["AzureBlobStorage:ContainerName"];
        }

        public async Task<string> SaveFileAsync(IFormFile file, string objectType, string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient($"{objectType}/{fileName}");

            using (var memoryStream = new MemoryStream())
            {
                using (var image = Image.Load(file.OpenReadStream()))
                {
                    image.Save(memoryStream, new WebpEncoder());
                }
                memoryStream.Position = 0;
                await blobClient.UploadAsync(memoryStream, true);
            }

            return blobClient.Uri.ToString();
        }
    }
}