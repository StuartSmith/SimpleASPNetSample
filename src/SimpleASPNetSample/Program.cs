using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using SimpleASPNetSample.Context;
using Microsoft.EntityFrameworkCore;

namespace SimpleASPNetSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new UltraSonicContext())
            {
                db.Database.Migrate();
            }

            using (var db = new PiGeneralContext())
            {
                db.Database.Migrate();
            }


            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
