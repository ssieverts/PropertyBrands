using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WeatherDataDal.Models;

namespace WeatherDataDal
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WeatherDataContext>
    {
        public WeatherDataContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();

            var builder = new DbContextOptionsBuilder<WeatherDataContext>();

            var connectionString = configuration.GetConnectionString("connectionString:DefaultConnection");

            builder.UseSqlServer("Data Source=SSIEVERTS-PC;Integrated Security=True;Initial Catalog=WeatherData;talog=Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new WeatherDataContext(builder.Options);
        }
    }
}