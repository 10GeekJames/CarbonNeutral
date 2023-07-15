namespace CarbonNeutral.Common.Services
{
    public class PlatformStateCacheService
    {
        private string? _appCulture;
        private int? _headspace;

        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
        private IJSRuntime JSRuntime;

        public PlatformStateCacheService(IJSRuntime JSRuntime){
            this.JSRuntime = JSRuntime;
            _ = InitStateFromCache();
        }
        private async Task InitStateFromCache(){
            _appCulture = await JSRuntime.InvokeAsync<string>("appCulture.get") ?? "en-US";
            _headspace = int.Parse(await JSRuntime.InvokeAsync<string>("headspace.get") ?? "-1");
        }
        public string AppCulture
        {
            get => _appCulture ?? "";
            set
            {
                _appCulture = value;
                var js = (IJSRuntime)JSRuntime;
                JSRuntime.InvokeVoidAsync("appCulture.set", value);
                NotifyStateChanged();
            }
        }
        public int Headspace
        {
            get => _headspace ?? -1;
        }

        public async Task UpdateHeadspace(int newValue) {   
            var currentValueAsString = await JSRuntime.InvokeAsync<string>("headspace.get");            
            var currentValue = int.Parse(currentValueAsString == "" ? "0" : currentValueAsString);
            if(newValue != currentValue)          {
                _headspace = newValue;
                var js = (IJSRuntime)JSRuntime;
                await JSRuntime.InvokeVoidAsync("headspace.set", newValue);
                NotifyStateChanged();        
            }            
        }
    }
}