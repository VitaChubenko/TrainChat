using TrainChat.Model.DTO;

namespace TrainChat.CQRS.Query.User
{
    public class GetUserByIdQuery : IQuery<UserDto>
    {
        public readonly int Id;

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
