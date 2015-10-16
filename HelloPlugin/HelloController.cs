using System.Web.Http;

namespace HelloPlugin
{
    [RoutePrefix("/hello")]
    public class HelloController : ApiController
    {
        private readonly IHelloService _service;

        public HelloController(IHelloService service)
        {
            _service = service;
        }

        [Route()]
        public HelloClientMessage GetEcho(string target)
        {
            return new HelloClientMessage()
            {
                to = target,
                message = _service.SayHello(target)
            };
        }
    }

    public class HelloClientMessage
    {
        public string to { get; set; }
        public string message { get; set; }
    }
}
