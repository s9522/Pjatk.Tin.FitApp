using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;
using Ninject.Web.Common;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace Pjatk.Tin.FitApp.Api.NinjectModules
{
    public class RavenModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDocumentStore>()
                .ToMethod(InitDocStore)
                .InSingletonScope();

            Bind<IDocumentSession>()
                .ToMethod(c => c.Kernel.Get<IDocumentStore>().OpenSession())
                .InRequestScope();
        }

        private IDocumentStore InitDocStore(IContext context)
        {
            IDocumentStore store = new EmbeddableDocumentStore
            {
                ConnectionStringName = "RavenDB_embedded"
            };
            store.Conventions.IdentityPartsSeparator = "-";
            store.Initialize();
            IndexCreation.CreateIndexes(Assembly.GetCallingAssembly(), store);
            return store;
        }
    }
}