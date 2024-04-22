using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Acme.FirstProjet;

[Dependency(ReplaceServices = true)]
public class FirstProjetBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FirstProjet";
}