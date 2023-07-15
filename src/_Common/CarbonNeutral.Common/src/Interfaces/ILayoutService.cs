namespace CarbonNeutral.Common.Interfaces;
public interface ILayoutService
{
    RenderFragment? ModuleAdminNav { get; }
    SetModuleAdminNav? ModuleAdminNavSetter { get; set; }
    void UpdateModuleAdminNav();

    RenderFragment? ModuleAdminSettings { get; }
    SetModuleAdminSettings? ModuleAdminSettingsSetter { get; set; }
    void UpdateModuleAdminSettings();

    RenderFragment? ModuleNav { get; }
    SetModuleNav? ModuleNavSetter { get; set; }
    void UpdateModuleNav();

    RenderFragment? ModuleSettings { get; }
    SetModuleSettings? ModuleSettingsSetter { get; set; }
    void UpdateModuleSettings();

    RenderFragment? ModuleBread { get; }
    SetModuleBread? ModuleBreadSetter { get; set; }
    void UpdateModuleBread();
    
    event PropertyChangedEventHandler PropertyChanged;
}
