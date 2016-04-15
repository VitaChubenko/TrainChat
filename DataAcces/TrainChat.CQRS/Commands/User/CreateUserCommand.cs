using TrainChat.Model.DTO;

namespace TrainChat.CQRS.Commands.User
{
    public class CreateUserCommand : ICommand
    {
        public readonly UserDto User;
        public CreateUserCommand(UserDto userDto)
        {
            User = userDto;
        }
    }
}
