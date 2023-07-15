namespace CarbonNeutral.Common.MasterPageSetters
{
    public class SetModuleAdminSettings : ComponentBase, IDisposable
    {
        [Inject]
        private ILayoutService? Layout { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected override void OnInitialized()
        {
            if (Layout != null)
            {
                Layout.ModuleAdminSettingsSetter = this;
            }
            base.OnInitialized();
        }

        protected override bool ShouldRender()
        {
            var shouldRender = base.ShouldRender();
            if (shouldRender)
            {
                Layout?.UpdateModuleAdminSettings();
            }
            return shouldRender;
        }

        public void Dispose()
        {
            if (Layout != null)
            {
                Layout.ModuleAdminSettingsSetter = null;
            }
        }

    }
}