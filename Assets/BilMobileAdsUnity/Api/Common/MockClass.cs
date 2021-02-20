

using System;
using System.Reflection;
using BilMobileAdsUnity.Api;
using UnityEngine;

namespace BilMobileAdsUnity.Common
{
    public class MockClass : IAdBanner, IAdInterstitial, IAdRewarded, IPBMobileAds
    {
        public MockClass()
        {
            // Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        // Disable warnings for unused MockClass ad events.
#pragma warning disable 67
        public event EventHandler<EventArgs> OnAdLoaded;
        public event EventHandler<EventArgs> OnAdOpened;
        public event EventHandler<EventArgs> OnAdClosed;
        public event EventHandler<EventArgs> OnAdClicked;
        public event EventHandler<EventArgs> OnAdLeftApplication;
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToShow;
        public event EventHandler<ADRewardItem> OnUserEarnedReward;
#pragma warning restore 67



        public void CreateBanner(string adUnitId, AdPosition position)
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name + " - adUnitId: " + adUnitId);
        }

        public void CreateInterstitial(string adUnitId)
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name + " - adUnitId: " + adUnitId);
        }

        public void CreateRewarded(string adUnitId)
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name + " - adUnitId: " + adUnitId);
        }

        public void DestroyBanner()
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        public void DestroyInterstitial()
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        public void DestroyRewarded()
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        public void DisableCOPPA()
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        public void EnableCOPPA()
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        public int GetHeightInPixelsBanner()
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
            return 0;
        }

        public int GetWidthInPixelsBanner()
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
            return 0;
        }

        public void HideBanner()
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        public void Initialize(bool testMode)
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        public bool IsReadyInterstitial()
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
            return true;
        }

        public bool IsReadyRewarded()
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
            return true;
        }

        public void LoadBanner()
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        public void PreLoadInterstitial()
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        public void PreLoadRewarded()
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        public void SetAppPauseOnBackground(bool pause)
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        public void SetGender(int gender)
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        public void SetPositionBanner(AdPosition adPosition)
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        public void SetYearOfBirth(int yearOfBirth)
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        public void ShowBanner()
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        public void ShowInterstitial()
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }

        public void ShowRewarded()
        {
            Debug.Log("MockClass: " + MethodBase.GetCurrentMethod().Name);
        }
    }
}