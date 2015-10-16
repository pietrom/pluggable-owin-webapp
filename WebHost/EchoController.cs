using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace WebHost
{
    [RoutePrefix("/echo")]
    public class EchoController: ApiController
    {
        [Route()]
        public EchoClientMessage GetEcho(string target)
        {
            return new EchoClientMessage()
            {
                to = target
            };
        }

        [Route("resources")]
        public ResourcesClientMessage GetResources()
        {
            return new ResourcesClientMessage()
            {
                Resources = GetResourcesList()
            };
        }

        private IEnumerable<string> GetResourcesList()
        {
            return GetType().Assembly.GetManifestResourceNames().Concat(new HelloPlugin.HelloPlugin().GetResourcesList());
        }

        public class ResourcesClientMessage
        {
            public IEnumerable<string> Resources;
        }

        public class EchoClientMessage
        {
            public string to { get; set; }
        }
    }
}
