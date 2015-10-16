using System.IO;

namespace HelloPlugin
{
    public class HelloService : IHelloService
    {
        public string SayHello(string to)
        {
            Stream stream = GetType().Assembly.GetManifestResourceStream("HelloPlugin.hello-template.txt");
            string template = new StreamReader(stream).ReadToEnd();
            return string.Format(template, to);
        }
    }
}
