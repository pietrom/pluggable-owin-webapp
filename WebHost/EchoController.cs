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

        public class EchoClientMessage
        {
            public string to { get; set; }
        }
    }
}
