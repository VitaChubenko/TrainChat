using System;
using TrainChat.Model;

namespace TrainChat.CQRS.UnitOfWork
{
    public class ChatContextUnitOfWork : IUnitOfWork
    {
        private readonly ChatContext context = new ChatContext();
        private readonly ChatContextReadOnly contextReadOnly = new ChatContextReadOnly();

        public ChatContextReadOnly ReadOnlyContext
        {

            get
            {
                return contextReadOnly;
            }
        }

        public ChatContext Context
        {
            get { return context; }
        }
        
        public ChatContextUnitOfWork(ChatContext context)
        {
            this.context = context;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            //context.SaveChanges();
            GC.SuppressFinalize(this);
        }
    }
}
