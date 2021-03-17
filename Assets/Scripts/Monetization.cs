using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
public class Monetization : MonoBehaviour , IUnityAdsListener
{ string ProjectID ="3712401";
    bool TestMode =false;
    string myPlacementId = "rewardedVideo";
    string VideoAd = "video";
    public Button RewardButton;//from the start menu and the get reward ingame
    public Button RewardInGame;
    public Button RewardButton2;// for the reward after die in game
    public Button Coins30;
    public Button Coins20;
    public bool isRewarded=false;
    [HideInInspector]
   // public static int RandomNumber=4;
 
    void Start()
    {
        
        Advertisement.Initialize(ProjectID, TestMode);
        Advertisement.AddListener(this);
       
       // RewardButton.gameObject.SetActive(false);
    }
    public void  DisplayInterstitialAD()
    {
        Advertisement.Show();
    }
    public void DisplayVideoAD()
    {
        Advertisement.Show(myPlacementId);
        isRewarded = true;
    }

   
    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(myPlacementId))
        {
            Advertisement.Show(myPlacementId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            //Debug.Log("win an price ");
            if (isRewarded == true)
            {
                int coin = PlayerPrefs.GetInt("TotalCoins") + 40;
                PlayerPrefs.SetInt("TotalCoins", coin);
                isRewarded = false;
            }
            if (GameMananger.ForMonetization == false&&GameMananger.ForMonetizationRestartButton==false)// ca sa nu mai apara buton de extralife dupa ce se termina reclama interstitial 
            {
                RandomReward();
            }
            else if(GameMananger.ForMonetization == false && GameMananger.ForMonetizationRestartButton == true)
            { }
            // Reward the user for watching the ad to completion.
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId)
        {
            RewardButton.gameObject.SetActive(true);
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
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
    public void  RandomReward()
    {
        int random = 0;
        if (random == 0)
        {
            RewardInGame.enabled = false;
            RewardButton2.gameObject.SetActive(true);
            RewardInGame.gameObject.SetActive(false);
        }
       /* else if (random == 1)
        {
            Coins30.gameObject.SetActive(true);
            int coin = PlayerPrefs.GetInt("TotalCoins") + 30;
            PlayerPrefs.SetInt("TotalCoins", coin);
            RewardInGame.enabled = false;
            RewardInGame.gameObject.SetActive(false);
        }
        else if (random == 2)
        {
            Coins20.gameObject.SetActive(true);
            int coin = PlayerPrefs.GetInt("TotalCoins") + 20;
            PlayerPrefs.SetInt("TotalCoins", coin);
            RewardInGame.enabled = false;
            RewardInGame.gameObject.SetActive(false);
        }*/
    }
}

