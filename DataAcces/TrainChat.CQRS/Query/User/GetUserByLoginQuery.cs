using TrainChat.Model.DTO;

namespace TrainChat.CQRS.Query.User
{
    public class GetUserByLoginQuery : IQuery<UserDto>
    {
        public readonly string Login;

        public GetUserByLoginQuery(string login)
        {
            Login = login;
        }
    }
}
