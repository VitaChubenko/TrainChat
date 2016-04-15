namespace TrainChat.Model.DTO
{
    public class UserDto : IModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }

        //public UserDto(string name, string login, string password)
        //{
        //    Name = name;
        //    Login = login;
        //    Password = password;
        //}
    }
}
