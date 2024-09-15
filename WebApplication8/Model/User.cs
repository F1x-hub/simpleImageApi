namespace WebApplication8.Model
{
    public class User
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UserImage>? UserImages { get; set; }
    }
}
