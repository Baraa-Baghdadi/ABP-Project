using Volo.Abp.Modularity;

namespace Acme.FirstProjet;

public abstract class FirstProjetApplicationTestBase<TStartupModule> : FirstProjetTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
