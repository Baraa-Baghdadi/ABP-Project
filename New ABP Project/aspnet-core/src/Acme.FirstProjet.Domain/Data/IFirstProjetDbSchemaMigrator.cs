using System.Threading.Tasks;

namespace Acme.FirstProjet.Data;

public interface IFirstProjetDbSchemaMigrator
{
    Task MigrateAsync();
}
