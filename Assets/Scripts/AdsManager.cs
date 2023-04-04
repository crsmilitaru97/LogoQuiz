

using GoogleMobileAds.Api;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour
{    
    public static string interstitial_wordFinish_id = "ca-app-pub-8089995158636506/3313117330";
    public static string rewarded_getPoints_id = "ca-app-pub-8089995158636506/1317509388";
    //AppID = "ca-app-pub-8089995158636506~2269937900";

    public static InterstitialAd wordFinish;
    public static RewardedAd getPoints;

    public static AdsManager instance;
    public static int adStep = 1;


    public static AdsManager Instance;
    public static bool shouldShowAd = false;

    int steps;
    readonly int stepToShow = 4;

    List<GameObject> rewardButtons = new List<GameObject>();

    #region Basic Events
    void Awake()
    {
        Instance = this;

        MobileAds.Initialize((InitializationStatus initStatus) => { });

        SceneManager.sceneLoaded += OnSceneLoaded;

        DontDestroyOnLoad(gameObject);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        rewardButtons.Clear();
        foreach (var item in GameObject.FindGameObjectsWithTag("Reward"))
        {
            rewardButtons.Add(item);
            if (getPoints != null)
            {
                item.SetActive(getPoints.CanShowAd());
            }
        }
    }

    void Start()
    {
        LoadRewardedAd();
    }
    #endregion

    #region Interstitial
    public void LoadAdIfCase()
    {
        steps++;
        shouldShowAd = steps == stepToShow;

        if (shouldShowAd)
        {
            steps = 0;
            LoadAd();
        }
    }

    public void LoadAd()
    {
        if (wordFinish != null)
        {
            wordFinish.Destroy();
            wordFinish = null;
        }

        var adRequest = new AdRequest.Builder()
             .AddKeyword("unity-admob-sample")
             .Build();

        InterstitialAd.Load(interstitial_wordFinish_id, adRequest,
          (InterstitialAd ad, LoadAdError error) =>
          {
              if (error != null || ad == null)
              {
                  return;
              }
              wordFinish = ad;
          });
    }

    public void ShowAd()
    {
        if (wordFinish != null && wordFinish.CanShowAd())
        {
            wordFinish.Show();
        }
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        wordFinish.Destroy();
    }
    #endregion

    /*
    #region Banner
    public void CreateBannerView()
    {
        if (bannerView != null)
        {
            DestroyBannerAd();
        }

        AdSize adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        bannerView = new BannerView(banner_ID, adaptiveSize, AdPosition.Bottom);
    }

    public void LoadBannerAd()
    {
        if (bannerView == null)
        {
            CreateBannerView();
        }
        var adRequest = new AdRequest.Builder()
            .AddKeyword("unity-admob-sample")
            .Build();

        bannerView.LoadAd(adRequest);
    }

    public void DestroyBannerAd()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
            bannerView = null;
        }
    }
    #endregion
    */

    #region Reward
    public void LoadRewardedAd()
    {
        if (getPoints != null)
        {
            getPoints.Destroy();
            getPoints = null;
        }

        foreach (var item in rewardButtons)
        {
            item.SetActive(false);
        }

        var adRequest = new AdRequest.Builder().Build();

        RewardedAd.Load(rewarded_getPoints_id, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    return;
                }

                foreach (var item in rewardButtons)
                {
                    item.SetActive(true);
                }
                getPoints = ad;
            });
    }

    public void ShowRewardedAd()
    {
        if (getPoints != null && getPoints.CanShowAd())
        {
            getPoints.Show((Reward reward) =>
            {
                RegisterReloadHandler(getPoints);
            });
        }
    }

    private void RegisterReloadHandler(RewardedAd ad)
    {
        //Values.AddPoints(25);

        ad.OnAdFullScreenContentClosed += () =>
        {
            LoadRewardedAd();
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            LoadRewardedAd();
        };
    }
    #endregion
}
