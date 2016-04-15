namespace TrainChat.CQRS.Commands
{
    //ICommandHandler<TCommand, out TKey> where TCommand : ICommand
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
    public interface ICommandHandler<in TCommand, out TKey> where TCommand : ICommand
    {
        TKey Handle(TCommand command);
    }
}
