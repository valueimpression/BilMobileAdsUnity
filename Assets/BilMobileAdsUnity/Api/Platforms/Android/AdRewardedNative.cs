using System;
using UnityEngine;

using BilMobileAdsUnity.Api;
using BilMobileAdsUnity.Common;

namespace BilMobileAdsUnity.Android
{
    public class AdRewardedNative : AndroidJavaProxy, IAdRewarded
    {
        private AndroidJavaObject rewaredNative; // JAVA Class

        public AdRewardedNative() : base(Utils.UnityADRewaredListenerClassName)
        {
            AndroidJavaClass uPlayerClass = new AndroidJavaClass(Utils.UnityPlayerClassName);
            AndroidJavaObject activity = uPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.rewaredNative = new AndroidJavaObject(Utils.RewardedClassName, activity, this);
        }

        #region Rewarded Events
        public event EventHandler<EventArgs> OnAdLoaded;
        public event EventHandler<EventArgs> OnAdOpened;
        public event EventHandler<EventArgs> OnAdClosed;
        public event EventHandler<ADRewardItem> OnUserEarnedReward;
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToShow;
        #endregion

        #region Rewarded Methor Implement
        public void CreateRewarded(string adUnitId)
        {
            this.rewaredNative.Call("create", adUnitId);
        }
        public void PreLoadRewarded()
        {
            this.rewaredNative.Call("preLoad");
        }
        public void ShowRewarded()
        {
            this.rewaredNative.Call("show");
        }
        public void DestroyRewarded()
        {
            this.rewaredNative.Call("destroy");
        }
        public bool IsReadyRewarded()
        {
            return this.rewaredNative.Call<bool>("isReady");
        }
        #endregion

        #region Callbacks from UADRewardedListener:
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
        public void onUserEarnedReward(string type, double amount)
        {
            if (this.OnUserEarnedReward != null)
            {
                ADRewardItem args = new ADRewardItem()
                {
                    Type = type,
                    Amount = amount
                };
                this.OnUserEarnedReward(this, args);
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
        public void onAdFailedToShow(string errorReason)
        {
            if (this.OnAdFailedToShow != null)
            {
                AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs()
                {
                    Message = errorReason
                };
                this.OnAdFailedToShow(this, args);
            }
        }
        #endregion
    }
}