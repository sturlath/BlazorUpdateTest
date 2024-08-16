using Volo.Abp.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace BlazorUpdateTest.Data;

public class BlazorUpdateTestDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public BlazorUpdateTestDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        
        /* We intentionally resolving the BlazorUpdateTestDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BlazorUpdateTestDbContext>()
            .Database
            .MigrateAsync();

    }
}
