using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ChangeCounselling.Data.Services;

namespace ChangeCounselling.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<SqlCounsellorData>()
                .As<ICounsellorData>()
                .InstancePerRequest();

            builder.RegisterType<SqlClientData>()
              .As<IClientData>()
              .InstancePerRequest();

            builder.RegisterType<SqlBookData>()
              .As<IBookData>()
              .InstancePerRequest();

            builder.RegisterType<SqlBillData>()
              .As<IBillData>()
              .InstancePerRequest();

            builder.RegisterType<SqlLoginData>()
              .As<ILoginData>()
              .InstancePerRequest();


            builder.RegisterType<CounsellorDbContext>().InstancePerRequest();
    

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}