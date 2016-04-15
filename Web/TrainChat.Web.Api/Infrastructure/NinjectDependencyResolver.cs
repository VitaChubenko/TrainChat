using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Ninject.Web.Common;
using TrainChat.CQRS.ReadModels;
using TrainChat.CQRS.UnitOfWork;
using TrainChat.CQRS.WriteModels;
using TrainChat.Service.Interfaces;
using TrainChat.Service.Services;

namespace TrainChat.Web.Api.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserReadModel>().To<UserReadModel>();
            kernel.Bind<IUserWriteModel>().To<UserWriteModel>();
            kernel.Bind<IUnitOfWork>().To<ChatContextUnitOfWork>().InRequestScope();
        }
    }
}