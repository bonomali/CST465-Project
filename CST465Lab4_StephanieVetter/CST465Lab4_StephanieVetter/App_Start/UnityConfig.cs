using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using CST465Lab4_StephanieVetter;
using CST465Lab4_StephanieVetter.Code.Repositories;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using CST465Lab4_StephanieVetter.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using CST465Lab4_StephanieVetter.Controllers;

namespace CST465Lab4_StephanieVetter
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IDataEntityRepository<BlogPost>, BlogDBRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IDataEntityRepository<Inventory>, InventoryRepository>();
            container.RegisterType<IDataEntityRepository<Category>, CategoriesRepository>();

            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IRoleStore<ApplicationRole, string>, RoleStore<ApplicationRole>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());
        }
    }
}