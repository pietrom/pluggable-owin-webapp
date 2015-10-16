using System;
using System.Net.Http;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Owin.Hosting;
using Owin;

namespace WebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";
            WebApp.Start<Startup>(url: baseAddress);
            /*

            // Start OWIN host 
            using ()
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/echo?target=World").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
            */
            Console.ReadLine();
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            IWindsorContainer container = new WindsorContainer();
            container.Register(
                Classes.FromAssemblyInDirectory(new AssemblyFilter(AppDomain.CurrentDomain.BaseDirectory))
                    .Where(t => typeof(ApiController).IsAssignableFrom(t)).LifestyleSingleton());

            config.DependencyResolver = new WindsorDependencyResolver(container);

            appBuilder.UseWebApi(config);
        }
    }
}
