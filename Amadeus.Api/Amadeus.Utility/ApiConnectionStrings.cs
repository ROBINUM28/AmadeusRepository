using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amadeus.Utility
{
 public static class ApiConnectionStrings
    {
 
        public static string ConnectionStringDB
        {
            get
            {
                var builder = new ConfigurationBuilder();

                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                var configuration = builder.Build();
                var connectionString = configuration.GetConnectionString("DB");
                return connectionString;


            }
        }
        
    }
}
