namespace CarbonNeutral.Common.MasterPageSetters
{
    public class SetModuleSettings : ComponentBase, IDisposable
    {
        [Inject]
        private ILayoutService? Layout { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected override void OnInitialized()
        {
            if (Layout != null)
            {
                Layout.ModuleSettingsSetter = this;
            }
            base.OnInitialized();
        }

        protected override bool ShouldRender()
        {
            var shouldRender = base.ShouldRender();
            if (shouldRender)
            {
                Layout?.UpdateModuleSettings();
            }
            return shouldRender;
        }

        public void Dispose()
        {
            if (Layout != null)
            {
                Layout.ModuleSettingsSetter = null;
            }
            GC.SuppressFinalize(this);
        }

    }
}