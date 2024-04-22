using Acme.FirstProjet.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.FirstProjet.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(FirstProjetEntityFrameworkCoreModule),
    typeof(FirstProjetApplicationContractsModule)
    )]
public class FirstProjetDbMigratorModule : AbpModule
{
}
