using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Web.Common;
using Repositories;
using Repositories.Contracts;
using System.Data.Entity;
using TelerikColours.Data;
using TelerikColours.Data.Contracts;
using TelerikColours.Services;
using TelerikColours.Services.Contracts;
using TelerikColours.Services.Contracts.Factories;

namespace TelerikColours.App_Start.NinjectModules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDbContext>().To<TelerikColoursDbContext>().InRequestScope();
            this.Bind<IFlightService>().To<FlightService>().InRequestScope();
            this.Bind<ILocationService>().To<LocationService>().InRequestScope();
            this.Bind<IFactoryService>().To<FactoryService>().InRequestScope();
            this.Bind<IAirportService>().To<AirportService>().InRequestScope();
            this.Bind<IAirlineService>().To<AirlineService>().InRequestScope();

            Kernel.Bind(typeof(IRepository<>)).To(typeof(EfRepository<>)).InRequestScope();

            this.Bind<IUnitOfWork>().To<EfUnitOfWork>().InRequestScope();

            this.Bind<ILocationFactory>().ToFactory().InRequestScope();
            this.Bind<IAirportFactory>().ToFactory().InRequestScope();
            this.Bind<IJobFactory>().ToFactory().InRequestScope();
            this.Bind<IMappedClassFactory>().ToFactory().InRequestScope();
        }
    }
}