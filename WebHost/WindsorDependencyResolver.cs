using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel;
using Castle.Windsor;

namespace WebHost
{
    internal class WindsorDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IWindsorContainer container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.container = container;
        }

        public object GetService(Type t)
        {
            return this.container.Kernel.HasComponent(t) ? this.container.Resolve(t) : null;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return this.container.ResolveAll(t).Cast<object>().ToArray();
        }

        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(this.container.Kernel);
        }

        public void Dispose()
        {
        }
    }
}
