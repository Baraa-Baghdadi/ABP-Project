using Acme.FirstProjet.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.FirstProjet.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class FirstProjetController : AbpControllerBase
{
    protected FirstProjetController()
    {
        LocalizationResource = typeof(FirstProjetResource);
    }
}
