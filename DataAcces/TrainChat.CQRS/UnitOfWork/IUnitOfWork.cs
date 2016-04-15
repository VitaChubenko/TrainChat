using System;
using TrainChat.Model;

namespace TrainChat.CQRS.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        ChatContextReadOnly ReadOnlyContext { get; }
        ChatContext Context { get; }
    }
}
