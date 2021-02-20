using System;
using UnityEngine;

using BilMobileAdsUnity.Api;
using BilMobileAdsUnity.Common;

namespace BilMobileAdsUnity.Android
{
    public class AdInterstitialNative : AndroidJavaProxy, IAdInterstitial
    {
        private AndroidJavaObject interstitialNative; // JAVA Class

        public AdInterstitialNative() : base(Utils.UnityADListenerClassName)
        {
            AndroidJavaClass uPlayerClass = new AndroidJavaClass(Utils.UnityPlayerClassName);
            AndroidJavaObject activity = uPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.interstitialNative = new AndroidJavaObject(Utils.InterstitialClassName, activity, this);
        }

        #region Interstitial Events
        public event EventHandler<EventArgs> OnAdLoaded;
        public event EventHandler<EventArgs> OnAdOpened;
        public event EventHandler<EventArgs> OnAdClosed;
        public event EventHandler<EventArgs> OnAdClicked;
        public event EventHandler<EventArgs> OnAdLeftApplication;
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;
        #endregion

        #region Interstitial Methor Implement
        public void CreateInterstitial(string adUnitId)
        {
            this.interstitialNative.Call("create", adUnitId);
        }
        public void PreLoadInterstitial()
        {
            this.interstitialNative.Call("preLoad");
        }
        public void ShowInterstitial()
        {
            this.interstitialNative.Call("show");
        }
        public void DestroyInterstitial()
        {
            this.interstitialNative.Call("destroy");
        }
        public bool IsReadyInterstitial()
        {
            return this.interstitialNative.Call<bool>("isReady");
        }
        #endregion

        #region Callbacks from UAdListener:
        public void onAdLoaded()
        {
            if (this.OnAdLoaded != null)
            {
                this.OnAdLoaded(this, EventArgs.Empty);
            }
        }
        public void onAdOpened()
        {
            if (this.OnAdOpened != null)
            {
                this.OnAdOpened(this, EventArgs.Empty);
            }
        }
        public void onAdClosed()
        {
            if (this.OnAdClosed != null)
            {
                this.OnAdClosed(this, EventArgs.Empty);
            }
        }
        public void onAdClicked()
        {
            if (this.OnAdClicked != null)
            {
                this.OnAdClicked(this, EventArgs.Empty);
            }
        }
        public void onAdLeftApplication()
        {
            if (this.OnAdLeftApplication != null)
            {
                this.OnAdLeftApplication(this, EventArgs.Empty);
            }
        }
        public void onAdFailedToLoad(string errorReason)
        {
            if (this.OnAdFailedToLoad != null)
            {
                AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs()
                {
                    Message = errorReason
                };
                this.OnAdFailedToLoad(this, args);
            }
        }
        #endregion
    }
}