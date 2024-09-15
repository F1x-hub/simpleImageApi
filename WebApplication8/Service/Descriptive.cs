namespace WebApplication8.Service
{
    public class Descriptive
    {
        public static async Task WriteImageInFileAsync(string newFileName, IFormFile imageFile)
        {
            using (var fileStream = new FileStream(newFileName, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

        }


        public static string GenerateImageSourceWithExtention(string path, IFormFile formFile)
        {
            List<string> extentions = new List<string>() { ".jpg", ".png", "PNG", ".jpeg", ".jfif" };

            string ext = Path.GetExtension(formFile.FileName);

            if (!extentions.Contains(ext))
                throw new Exception("not valid extention");

            string newFileName = Guid.NewGuid().ToString();

            return path + newFileName + ext;
        }


        public static string CreateImageDirectory(string contentPath, string folderName)
        {
            var path = Path.Combine(contentPath, folderName);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }
    }
}
