using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication8.Model
{
    public class UserImage
    {
        public int Id { get; set; }
        [NotMapped]
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        public string ImageSource { get; set; }
    }
}
