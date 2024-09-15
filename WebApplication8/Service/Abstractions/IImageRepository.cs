using WebApplication8.Model;

namespace WebApplication8.Service.Abstractions
{
    public interface IImageRepository
    {
        Task<string> GenerateImageSource(IFormFile imageFile);

        Task SaveImageInDatabase(UserImage userImage);
    }
}
