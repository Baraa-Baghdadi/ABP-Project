using System;
using System.Collections.Generic;
using System.Text;
using Acme.FirstProjet.Localization;
using Volo.Abp.Application.Services;

namespace Acme.FirstProjet;

/* Inherit your application services from this class.
 */
public abstract class FirstProjetAppService : ApplicationService
{
    protected FirstProjetAppService()
    {
        LocalizationResource = typeof(FirstProjetResource);
    }
}
