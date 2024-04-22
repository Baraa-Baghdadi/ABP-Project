using Volo.Abp.Modularity;

namespace Acme.FirstProjet;

[DependsOn(
    typeof(FirstProjetDomainModule),
    typeof(FirstProjetTestBaseModule)
)]
public class FirstProjetDomainTestModule : AbpModule
{

}
