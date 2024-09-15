using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Model;
using WebApplication8.Service.Abstractions;
using WebApplication8.Service.Implementations;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IImageRepository _imageRepository;
        public UserController(IUserRepository repository, IImageRepository imageRepository)
        {
            _repository = repository;
            _imageRepository = imageRepository;
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser([FromForm] User user, [FromForm] List<IFormFile>? imageFiles)
        {
            var createdUser = await _repository.AddUser(user);

            
            if (imageFiles != null && imageFiles.Any())
            {
                foreach (var file in imageFiles)
                {
                    var userImage = new UserImage
                    {
                        UserId = createdUser.Id, 
                        ImageSource = await _imageRepository.GenerateImageSource(file)
                    };
                    await _imageRepository.SaveImageInDatabase(userImage);
                }
            }

            return Ok(createdUser);
        }
        [HttpGet("Get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _repository.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("get-user/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _repository.GetUserById(id);
            return Ok(result);
        }
    }
}
