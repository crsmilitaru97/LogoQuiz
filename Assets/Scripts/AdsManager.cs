using GoogleMobileAds.Api;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public string AppID = "ca-app-pub-8089995158636506~2269937900";

    public static string interstitial_wordFinish_id = "ca-app-pub-8089995158636506/3313117330";
    public static string rewarded_getPoints_id = "ca-app-pub-8089995158636506/1317509388";

    string interstitial_test = "ca-app-pub-3940256099942544/1033173712";
    string getPoints_test = "ca-app-pub-3940256099942544/5224354917";

    public static InterstitialAd wordFinish;
    public static InterstitialAd newCategory;
    public static RewardedAd getPoints;

    public static AdsManager instance;
    public static int adStep = 1;

    public bool isTest;
    private void Awake()
    {
        MobileAds.Initialize(initStatus => { });
    }

    private void Start()
    {
        if (isTest)
        {
            interstitial_wordFinish_id = interstitial_test;
            rewarded_getPoints_id = getPoints_test;
        }

        DontDestroyOnLoad(gameObject);
    }

    public static InterstitialAd LoadInterstitial()
    {
        wordFinish = new InterstitialAd(interstitial_wordFinish_id);

        Debug.Log("Ad loads");
        AdRequest adRequest = new AdRequest.Builder().Build();
        wordFinish.LoadAd(adRequest);

        return wordFinish;
    }
    public static void ShowInterstitial(InterstitialAd ad)
    {
        Debug.Log("Ad show");
        ad.Show();
    }

    public static RewardedAd LoadRewarded()
    {
        getPoints = new RewardedAd(rewarded_getPoints_id);

        Debug.Log("Ad loads");
        AdRequest adRequest = new AdRequest.Builder().Build();
        getPoints.LoadAd(adRequest);

        return getPoints;

    }
    public static void ShowRewarded(RewardedAd ad)
    {
        Debug.Log("Ad show");
        ad.Show();
    }
}
