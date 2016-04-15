using TrainChat.Model.DTO;

namespace TrainChat.CQRS.Commands.User
{
    public class UpdateUserCommand : ICommand
    {
        public readonly UserDto User;
        public UpdateUserCommand(UserDto userDto)
        {
            User = userDto;
        }
    }
}
