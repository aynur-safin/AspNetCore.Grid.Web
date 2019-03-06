using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace NonFactors.Mvc.Grid.Web
{
    public class Program
    {
        public static void Main()
        {
            new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseIISIntegration()
                .UseKestrel()
                .Build()
                .Run();
        }
    }
}
