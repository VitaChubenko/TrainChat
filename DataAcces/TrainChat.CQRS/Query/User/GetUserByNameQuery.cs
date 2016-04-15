using TrainChat.Model.DTO;

namespace TrainChat.CQRS.Query.User
{
    public class GetUserByNameQuery : IQuery<UserDto>
    {
        public readonly string Name;

        public GetUserByNameQuery(string name)
        {
            Name = name;
        }
    }
}
