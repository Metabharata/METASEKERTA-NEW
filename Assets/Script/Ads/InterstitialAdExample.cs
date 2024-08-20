using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;


public class InterstitialAdExample : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    string tokenUser;
    int idUser;
    string _adUnitId;

    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // Show the loaded content in the Ad Unit:
    public void ShowAd()
    {
        // Note that if the ad content wasn't previously loaded, this method will fail
        Debug.Log("Showing Ad: " + _adUnitId);
        Advertisement.Show(_adUnitId, this);
        tokenUser = PlayerPrefs.GetString("token");
        idUser = PlayerPrefs.GetInt("id");
    }

    // Implement Load Listener and Show Listener interface methods: 
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
    }

    public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
        if (tokenUser == "")
        {
            SceneManager.LoadScene("Login");
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
        if (tokenUser == "")
        {
            SceneManager.LoadScene("Login");
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void OnUnityAdsShowStart(string _adUnitId) { }
    public void OnUnityAdsShowClick(string _adUnitId) { }
    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (_adUnitId.Equals(_adUnitId))
        {
            if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
            {
                Debug.Log("Unity Ads Interstitial Ad Completed");
                if (tokenUser == "")
                {
                    SceneManager.LoadScene("Login");
                }
                else
                {
                    SceneManager.LoadScene("MainMenu");
                }
            }
            else if (showCompletionState == UnityAdsShowCompletionState.SKIPPED)
            {
                Debug.Log("Unity Ads Interstitial Ad Skipped");
                if (tokenUser == "")
                {
                    SceneManager.LoadScene("Login");
                }
                else
                {
                    SceneManager.LoadScene("MainMenu");
                }
                // Put your logic here for handling a skipped ad
                // For example, you might want to show a message to the user or reward them with something.
            }
            // else if (showCompletionState == UnityAdsShowCompletionState.FAILED)
            // {
            //     Debug.Log("Unity Ads Interstitial Ad Failed");
            //     // Put your logic here for handling a failed ad
            //     // For example, you might want to retry showing the ad or inform the user about the failure.
            // }
        }
    }
}