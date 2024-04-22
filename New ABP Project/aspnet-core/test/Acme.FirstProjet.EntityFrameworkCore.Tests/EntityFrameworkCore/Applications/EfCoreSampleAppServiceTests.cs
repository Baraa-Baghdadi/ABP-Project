using Acme.FirstProjet.Samples;
using Xunit;

namespace Acme.FirstProjet.EntityFrameworkCore.Applications;

[Collection(FirstProjetTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<FirstProjetEntityFrameworkCoreTestModule>
{

}
