using System.ComponentModel.DataAnnotations;
using TrainChat.Model;

namespace TrainChat.Web.Api.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Range(1, 35, ErrorMessage = "The Role field is required")]
        public Roles Role { get; set; }

    }
}