using WebApplication8.Data;
using WebApplication8.Model;
using WebApplication8.Service.Abstractions;

namespace WebApplication8.Service.Implementations
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ImageContext _context;
        public ImageRepository(IWebHostEnvironment environment, ImageContext imageContext) 
        {
            _environment = environment;
            _context = imageContext;

        }
        public async Task<string> GenerateImageSource(IFormFile imageFile)
        {
            string contentPath = _environment.ContentRootPath;
            string folder = Descriptive.CreateImageDirectory(contentPath, "Uploads\\");

            string newFileName = Descriptive.GenerateImageSourceWithExtention(folder, imageFile);

            await Descriptive.WriteImageInFileAsync(newFileName, imageFile);

            return newFileName;
        }

        public async Task SaveImageInDatabase(UserImage userImage)
        {
            await _context.UserImages.AddAsync(userImage);
            await _context.SaveChangesAsync();
        }
    }
}
