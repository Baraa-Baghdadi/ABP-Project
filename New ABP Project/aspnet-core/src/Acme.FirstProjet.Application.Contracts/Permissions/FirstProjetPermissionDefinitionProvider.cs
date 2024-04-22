using Acme.FirstProjet.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.FirstProjet.Permissions;

public class FirstProjetPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(FirstProjetPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(FirstProjetPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FirstProjetResource>(name);
    }
}
