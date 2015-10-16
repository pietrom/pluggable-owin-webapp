using System.Web.Http;

namespace HelloPlugin
{
    [RoutePrefix("/hello")]
    public class HelloController : ApiController
    {
        [Route()]
        public HelloClientMessage GetEcho(string target)
        {
            return new HelloClientMessage()
            {
                to = target,
                message = string.Format("Hello, {0}!", target)
            };
        }
    }

    public class HelloClientMessage
    {
        public string to { get; set; }
        public string message { get; set; }
    }
}
