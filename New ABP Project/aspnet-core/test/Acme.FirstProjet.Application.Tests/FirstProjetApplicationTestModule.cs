using Volo.Abp.Modularity;

namespace Acme.FirstProjet;

[DependsOn(
    typeof(FirstProjetApplicationModule),
    typeof(FirstProjetDomainTestModule)
)]
public class FirstProjetApplicationTestModule : AbpModule
{

}
