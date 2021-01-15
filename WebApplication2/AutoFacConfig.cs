using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using WebApplication1.Implementation;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1
{
    public class AutoFacConfig
    {
        public static void ConfigureContainer()
        {
            var bulder = new ContainerBuilder();
            bulder.RegisterControllers(typeof(MvcApplication).Assembly);

            bulder.RegisterType<CityRepoService>().As<ICityRepo<City>>();
            var conteainer = bulder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(conteainer));
        }
    }
}