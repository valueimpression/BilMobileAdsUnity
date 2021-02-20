using UnityEngine;
using BilMobileAdsUnity.Api;
using System;

public class AdManager : MonoBehaviour
{

    private void Start()
    {
        PBMobileAds.Initialize(false);
    }

    #region BilMobileAdsUnity SDK: 
    public void initSDK()
    {
        PBMobileAds.Initialize(false);
    }
    public void enableCOPPA()
    {
        PBMobileAds.EnableCOPPA();
    }
    public void disableCOPPA()
    {
        PBMobileAds.DisableCOPPA();
    }
    public void setGender()
    {
        PBMobileAds.SetGender(Gender.Male);
    }
    public void setYear()
    {
        PBMobileAds.SetYearOfBirth(1991);
    }
    #endregion

    #region AdBanner: 
    private AdBanner adBanner;
    public void initBanner()
    {
        // if (this.adBanner != null) return;
        this.adBanner = new AdBanner("13b7e996-4aa3-40f5-b33e-54914d04bdcb", AdPosition.TopCenter);
    }
    public void destroyBanner()
    {
        this.adBanner.Destroy();
        // this.adBanner = null;
    }
    public void loadBanner()
    {
        this.adBanner.Load();
    }
    int count = 1;
    public void changePositionBanner()
    {
        switch (count)
        {
            case 0:
                this.adBanner.SetPosition(AdPosition.TopCenter);
                break;
            case 1:
                this.adBanner.SetPosition(AdPosition.TopLeft);
                break;
            case 2:
                this.adBanner.SetPosition(AdPosition.TopRight);
                break;
            case 3:
                this.adBanner.SetPosition(AdPosition.BottomCenter);
                break;
            case 4:
                this.adBanner.SetPosition(AdPosition.BottomLeft);
                break;
            case 5:
                this.adBanner.SetPosition(AdPosition.BottomRight);
                break;
            case 6:
                this.adBanner.SetPosition(AdPosition.Center);
                break;
        }
        count++;
        if (count > 6) count = 0;
    }
    public void showBanner()
    {
        this.adBanner.Show();
    }
    public void hideBanner()
    {
        this.adBanner.Hide();
    }
    public void getBannerWidth()
    {
        Debug.Log("Banner Width: " + this.adBanner.GetWidthInPixels());
    }
    public void getBannerHeight()
    {
        Debug.Log("Banner Height: " + this.adBanner.GetHeightInPixels());
    }
    #endregion

    #region AdInterstitial: 
    private AdInterstitial adInterstitial;
    public void initFull()
    {
        if (this.adInterstitial != null) return;

        this.adInterstitial = new AdInterstitial("3bad632c-26f8-4137-ae27-05325ee1b30c");
        this.adInterstitial.OnAdLoaded += OnFullAdLoaded;
        this.adInterstitial.OnAdOpened += OnFullAdOpended;
        this.adInterstitial.OnAdClosed += OnFullAdClosed;

        PBMobileAds.SetAppPauseOnBackground(true);
    }
    private void OnFullAdClosed(object sender, EventArgs e)
    {
        Debug.Log("HNL Full Closed: " + e);
    }
    private void OnFullAdOpended(object sender, EventArgs e)
    {
        Debug.Log("HNL Full Opended: " + e);
    }
    private void OnFullAdLoaded(object sender, EventArgs e)
    {
        Debug.Log("HNL Full Loaded: " + e);
    }
    public void preloadFull()
    {
        this.adInterstitial.PreLoad();
        PBMobileAds.SetAppPauseOnBackground(false);
    }
    public void showFull()
    {
        this.adInterstitial.Show();

    }
    public void destroyFull()
    {
        this.adInterstitial.Destroy();
    }
    #endregion

    #region AdRewarded: 
    private AdRewarded adRewarded;
    public void initRewarded()
    {
        if (this.adRewarded != null) return;

        this.adRewarded = new AdRewarded("d4aa579a-1655-452b-9502-b16ed31d2a99");
        this.adRewarded.OnAdLoaded += OnRewardedAdLoaded;
        this.adRewarded.OnUserEarnedReward += OnUserEarnedReward;
    }
    private void OnRewardedAdLoaded(object sender, EventArgs e)
    {
        Debug.Log("HNL Rewarded Loaded: " + e);
    }
    private void OnUserEarnedReward(object sender, ADRewardItem e)
    {
        Debug.Log("HNL Type:" + e.Type + " | Amount: " + e.Amount);
    }
    public void preloadRewarded()
    {
        this.adRewarded.PreLoad();
    }
    public void showRewarded()
    {
        this.adRewarded.Show();
    }
    #endregion
}
