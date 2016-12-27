[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MedicalJournal.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MedicalJournal.App_Start.NinjectWebCommon), "Stop")]

namespace MedicalJournal.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Data;
    using MedicalJournal.Service;
    using MedicalJournal.Repository;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MedicalJournal.Models;
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDbContext>().To<JournalDbContext>().InRequestScope();
            kernel.Bind<IdentityDbContext<ApplicationUser>>().To<ApplicationDbContext>().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InRequestScope();
            kernel.Bind<IPublisherService>().To<PublisherService>();
            kernel.Bind(typeof(IPubRepository<>)).To(typeof(PubRepository<>)).InRequestScope();
            kernel.Bind<IPubService>().To<PubService>();
            kernel.Bind<IJournalTypeService>().To<JournalTypeService>();
            kernel.Bind<IMedicJournallService>().To<MedicJournallService>();
            kernel.Bind<IJournalSubscriberService>().To<JournalSubscriberService>();
            
        }
    }
}
