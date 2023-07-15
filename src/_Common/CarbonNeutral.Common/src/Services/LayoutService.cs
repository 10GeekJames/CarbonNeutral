namespace CarbonNeutral.Common.Services
{
    public class LayoutService : ILayoutService, INotifyPropertyChanged
    {
        public SetModuleAdminNav? ModuleAdminNavSetter
        {
            get => moduleAdminNavSetter;
            set
            {
                if (moduleAdminNavSetter == value) return;
                moduleAdminNavSetter = value;
                UpdateModuleAdminNav();
            }
        }

        public SetModuleAdminSettings? ModuleAdminSettingsSetter
        {
            get => moduleAdminSettingsSetter;
            set
            {
                if (moduleAdminSettingsSetter == value) return;
                moduleAdminSettingsSetter = value;
                UpdateModuleAdminSettings();
            }
        }

        public SetModuleNav? ModuleNavSetter
        {
            get => moduleNavSetter;
            set
            {
                if (moduleNavSetter == value) return;
                moduleNavSetter = value;
                UpdateModuleNav();
            }
        }

        public SetModuleBread? ModuleBreadSetter
        {
            get => moduleBreadSetter;
            set
            {
                if (moduleBreadSetter == value) return;
                moduleBreadSetter = value;
                UpdateModuleBread();
            }
        }

        public SetModuleSettings? ModuleSettingsSetter
        {
            get => moduleSettingsSetter;
            set
            {
                if (moduleSettingsSetter == value) return;
                moduleSettingsSetter = value;
                UpdateModuleSettings();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public RenderFragment? ModuleAdminNav => ModuleAdminNavSetter?.ChildContent;
        private SetModuleAdminNav? moduleAdminNavSetter;
        public void UpdateModuleAdminNav() => NotifyPropertyChanged(nameof(ModuleAdminNav));

        public RenderFragment? ModuleAdminSettings => ModuleAdminSettingsSetter?.ChildContent;
        private SetModuleAdminSettings? moduleAdminSettingsSetter;
        public void UpdateModuleAdminSettings() => NotifyPropertyChanged(nameof(ModuleAdminSettings));

        public RenderFragment? ModuleNav => ModuleNavSetter?.ChildContent;
        private SetModuleNav? moduleNavSetter;
        public void UpdateModuleNav() => NotifyPropertyChanged(nameof(ModuleNav));

        public RenderFragment? ModuleSettings => ModuleSettingsSetter?.ChildContent;
        private SetModuleSettings? moduleSettingsSetter;
        public void UpdateModuleSettings() => NotifyPropertyChanged(nameof(ModuleSettings));

        public RenderFragment? ModuleBread => ModuleBreadSetter?.ChildContent;
        private SetModuleBread? moduleBreadSetter;
        public void UpdateModuleBread() => NotifyPropertyChanged(nameof(ModuleBread));
    }
}
