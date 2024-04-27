namespace Acme.FirstProjet.Permissions;

public static class FirstProjetPermissions
{
    public const string GroupName = "FirstProjet";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class Dashboard
    {
        public const string DashboardGroup = GroupName + ".Dashboard";
        public const string Host = DashboardGroup + ".Host";
        public const string Tenant = DashboardGroup + ".Tenant";

    }

  public static class Patients
  {
    public const string Default = GroupName + ".Patients";

  }

  public static class Providers
  {
    public const string Default = GroupName + ".Providers";
    public const string downloadQrCode = GroupName + ".Providers.downloadQrCode";

  }
}
