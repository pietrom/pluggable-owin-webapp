namespace HelloPlugin
{
    public class HelloService : IHelloService
    {
        public string SayHello(string to)
        {
            return string.Format("Hello, {0}!!!", to);
        }
    }
}
