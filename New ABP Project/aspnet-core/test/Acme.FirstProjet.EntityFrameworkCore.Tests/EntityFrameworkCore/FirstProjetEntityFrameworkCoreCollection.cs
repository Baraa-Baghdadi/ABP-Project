using Xunit;

namespace Acme.FirstProjet.EntityFrameworkCore;

[CollectionDefinition(FirstProjetTestConsts.CollectionDefinitionName)]
public class FirstProjetEntityFrameworkCoreCollection : ICollectionFixture<FirstProjetEntityFrameworkCoreFixture>
{

}
