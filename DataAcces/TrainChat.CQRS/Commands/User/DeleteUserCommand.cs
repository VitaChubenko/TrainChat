namespace TrainChat.CQRS.Commands.User
{
    public class DeleteUserCommand : ICommand
    {
        public readonly int Id;

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
