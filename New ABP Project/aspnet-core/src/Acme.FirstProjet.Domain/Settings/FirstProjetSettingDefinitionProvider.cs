using Volo.Abp.Settings;

namespace Acme.FirstProjet.Settings;

public class FirstProjetSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(FirstProjetSettings.MySetting1));
    }
}
