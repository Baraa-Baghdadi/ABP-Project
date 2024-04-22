using Acme.FirstProjet.Samples;
using Xunit;

namespace Acme.FirstProjet.EntityFrameworkCore.Domains;

[Collection(FirstProjetTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<FirstProjetEntityFrameworkCoreTestModule>
{

}
