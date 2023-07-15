using AccountModuleCore.Entities;

namespace CarbonNeutral.Common.Services;
public class PlatformCacheService
{
    private IAccountModuleDataService _accountModuleHttpClient;
    public PlatformCacheService(IAccountModuleDataService knownAccountModuleClient)
    {
        _accountModuleHttpClient = knownAccountModuleClient;
    }
    public KnownUserViewModel KnownUser { get; set; } = null;
    public KnownBusinessWebsiteViewModel KnownBusinessWebsite { get; set; } = new();
    public KnownBusinessViewModel KnownBusiness { get; set; } = new();
    public bool HasInitRun { get; set; } = false;
    public bool IsOwner { get; private set; } = false;
    public bool IsCoHost { get; private set; } = false;

    private bool _userDataIsReady = false;
    private bool _businessDataIsReady = false;
    private bool _appDataIsReady = false;
    private string _currentModule = "";
    private string _currentSubModule = "";
    public event Action OnChange;
    public event Action OnRoomChange;
    public event Action OnMenuChange;
    public event Action OnSkinChange;
    private void NotifyStateChanged() => OnChange?.Invoke();
    private void NotifyOnMenuChange() => OnMenuChange?.Invoke();
    private void NotifyOnRoomChange() => OnRoomChange?.Invoke();
    private void NotifyOnSkinChange() => OnSkinChange?.Invoke();
    public bool UserDataIsReady
    {
        get => _userDataIsReady;
    }
    public bool AppDataIsReady
    {
        get => _appDataIsReady;
    }
    public bool BusinessDataIsReady
    {
        get => _businessDataIsReady;
    }
    public void ResetMenuData()
    {
    }

    public async Task InitAppDataAsync(bool isAuthenticated)
    {
        if (isAuthenticated)
        {
            KnownBusinessWebsite = await _accountModuleHttpClient.KnownBusinessWebsiteGetAsync();
            Console.WriteLine($"InitAppDataAsync load data > {KnownBusinessWebsite?.Name}");
            if (KnownBusinessWebsite != null)
            {
                SetBusinessDataToReady();
                await Task.Delay(50);
            }
            KnownUser = await _accountModuleHttpClient.KnownUserGetAsync();
            Console.WriteLine($"InitAppDataAsync user from api state > {KnownUser?.UserId}");
            if (KnownUser != null)
            {
                SetUserDataToReady();
                await Task.Delay(50);
            }
        }
        else if (!isAuthenticated)
        {
            throw new Exception("Must be authenticated");
        }
        SetAppDataToReady();
        await Task.Yield();
    }
    public void UpdateMenu()
    {
        NotifyOnMenuChange();
    }

    public void UpdateSkin()
    {
        NotifyOnSkinChange();
    }
    public bool AllIsInit
    {
        get => _appDataIsReady && _userDataIsReady;
    }
    private void SetUserDataToReady(bool value = true)
    {
        _userDataIsReady = value;
        NotifyStateChanged();
    }
    private void SetBusinessDataToReady(bool value = true)
    {
        _businessDataIsReady = value;
        NotifyStateChanged();
    }
    public void SetAppDataToReady(bool value = true)
    {
        _appDataIsReady = value;
        NotifyStateChanged();
        NotifyOnMenuChange();
    }

    public void SetKnownBusinessWebsiteProfile(KnownBusinessWebsiteProfileViewModel knownBusinessWebsiteProfile)
    {
        KnownBusinessWebsite.KnownBusinessWebsiteProfile = knownBusinessWebsiteProfile;
        NotifyStateChanged();
    }

    public string CurrentModule => _currentModule;
    public string CurrentSubModule => _currentSubModule;
    public void SetCurrentModule(string module)
    {
        this._currentModule = module;
    }
    public void SetCurrentSubModule(string subModule)
    {
        this._currentSubModule = subModule;
    }
}
