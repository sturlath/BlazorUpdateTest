using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BlazorUpdateTest.Data;

public class BlazorUpdateTestDbContextFactory : IDesignTimeDbContextFactory<BlazorUpdateTestDbContext>
{
    public BlazorUpdateTestDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<BlazorUpdateTestDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new BlazorUpdateTestDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}