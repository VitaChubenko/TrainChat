using System.Collections.Generic;
using TrainChat.Model.DTO;

namespace TrainChat.CQRS.Query.User
{
    public class GetAllUsersQuery : IQuery<List<UserDto>>
    {
    }
}
