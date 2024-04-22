using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Acme.FirstProjet.Data;

/* This is used if database provider does't define
 * IFirstProjetDbSchemaMigrator implementation.
 */
public class NullFirstProjetDbSchemaMigrator : IFirstProjetDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
