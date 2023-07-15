namespace CarbonNeutral.Common.MasterPageSetters
{
    public class SetModuleNav : ComponentBase, IDisposable
    {
        [Inject]
        private ILayoutService? Layout { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected override void OnInitialized()
        {
            if (Layout != null)
            {
                Layout.ModuleNavSetter = this;
            }
            base.OnInitialized();
        }

        protected override bool ShouldRender()
        {
            var shouldRender = base.ShouldRender();
            if (shouldRender)
            {
                Layout?.UpdateModuleNav();
            }
            return shouldRender;
        }

        public void Dispose()
        {
            if (Layout != null)
            {
                Layout.ModuleNavSetter = null;
            }
        }

    }
}