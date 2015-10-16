using System.Collections.Generic;

namespace HelloPlugin
{
    public class HelloPlugin
    {
        public IEnumerable<string> GetResourcesList()
        {
            return GetType().Assembly.GetManifestResourceNames();
        }
    }
}
