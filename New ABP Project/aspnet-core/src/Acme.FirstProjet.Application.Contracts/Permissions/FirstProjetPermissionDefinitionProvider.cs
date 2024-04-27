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
        myGroup.AddPermission(FirstProjetPermissions.Dashboard.Host, L("Permission:Dashboard"),Volo.Abp.MultiTenancy.MultiTenancySides.Host);
        myGroup.AddPermission(FirstProjetPermissions.Dashboard.Tenant, L("Permission:Dashboard"),Volo.Abp.MultiTenancy.MultiTenancySides.Tenant);

        var patientPermission = myGroup.AddPermission(FirstProjetPermissions.Patients.Default, L("Permission:Patients"));
        var providerPermission = myGroup.AddPermission(FirstProjetPermissions.Providers.Default, L("Permission:Providers"));
        var qrDownloadPermission = myGroup.AddPermission(FirstProjetPermissions.Providers.downloadQrCode, L("Permission:DownloadQrCode"));
  }

  private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FirstProjetResource>(name);
    }
}
