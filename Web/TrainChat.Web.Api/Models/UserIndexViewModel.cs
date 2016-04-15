using Roles = TrainChat.Model.Roles;

namespace TrainChat.Web.Api.Models
{
    public class UserIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public Roles Role { get; set; }
    }
}