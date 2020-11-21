
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class Unityadsmanager : MonoBehaviour
{
    string gameId = "3902477";
    bool testMode = true;
    public string placementId = "bannerPlacement";
 [HideInInspector]  public bool checkgameoverforads;
  
    void Start()
    {
       
        // Initialize the Ads service:
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenInitialized());
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }
   
    private void Update()
    {
        
     if (checkgameoverforads)
        {
          
            Advertisement.Show();
            checkgameoverforads = false;
        }
    }
    IEnumerator ShowBannerWhenInitialized()
     {
   
    while (!Advertisement.isInitialized)
    {
        yield return new WaitForSeconds(0.5f);
    }
    Advertisement.Banner.Show(placementId);
      }
     public void displayIntertitialads()
    {
        Advertisement.Show();
    }
    public void ShowInterstitialAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }

   
  
   
}

