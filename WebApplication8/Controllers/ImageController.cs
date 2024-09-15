using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Model;
using WebApplication8.Service.Abstractions;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        private readonly IUserRepository _userRepository;

        public ImageController(IImageRepository imageRepository, IUserRepository userRepository)
        {
            _imageRepository = imageRepository;
            _userRepository = userRepository;
        }

        [HttpPost("add-user-image/{id}")]
        public async Task<IActionResult> AddUserImage(int id, List<IFormFile> imageFile)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null) 
                return NotFound("product not found");

            List<UserImage> userImages = new List<UserImage>();

            foreach (var perUser in imageFile)
            {
                UserImage userImage = new UserImage();
                userImage.UserId = user.Id;
                userImage.ImageSource = await _imageRepository.GenerateImageSource(perUser);

                userImages.Add(userImage);
            }

            foreach (var perUser in userImages)
            {
                await _imageRepository.SaveImageInDatabase(perUser);
            }

            return Ok(userImages);
        }
    }
}
