using Volo.Abp.Modularity;

namespace Acme.FirstProjet;

/* Inherit from this class for your domain layer tests. */
public abstract class FirstProjetDomainTestBase<TStartupModule> : FirstProjetTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
