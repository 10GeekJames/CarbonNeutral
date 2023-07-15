namespace CarbonNeutral.Common.MasterPageSetters
{
    public class SetModuleBread : ComponentBase, IDisposable
    {
        [Inject]
        private ILayoutService? Layout { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected override void OnInitialized()
        {
            if (Layout != null)
            {
                Layout.ModuleBreadSetter = this;
            }
            base.OnInitialized();
        }

        protected override bool ShouldRender()
        {
            var shouldRender = base.ShouldRender();
            if (shouldRender)
            {
                Layout?.UpdateModuleBread();
            }
            return shouldRender;
        }

        public void Dispose()
        {
            if (Layout != null)
            {
                Layout.ModuleBreadSetter = null;
            }
        }

    }
}