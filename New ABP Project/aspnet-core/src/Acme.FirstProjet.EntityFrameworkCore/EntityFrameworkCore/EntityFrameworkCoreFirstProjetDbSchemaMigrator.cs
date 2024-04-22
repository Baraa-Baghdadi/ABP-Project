using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Acme.FirstProjet.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.FirstProjet.EntityFrameworkCore;

public class EntityFrameworkCoreFirstProjetDbSchemaMigrator
    : IFirstProjetDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreFirstProjetDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the FirstProjetDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<FirstProjetDbContext>()
            .Database
            .MigrateAsync();
    }
}
