using System;
using BilMobileAdsUnity.Api;
using BilMobileAdsUnity.Common;
using UnityEngine;

namespace BilMobileAdsUnity.Android
{
    public class AdBannerNative : AndroidJavaProxy, IAdBanner
    {
        private AndroidJavaObject bannerNative; // JAVA Class

        public AdBannerNative() : base(Utils.UnityADListenerClassName)
        {
            AndroidJavaClass uPlayerClass = new AndroidJavaClass(Utils.UnityPlayerClassName);
            AndroidJavaObject activity = uPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.bannerNative = new AndroidJavaObject(Utils.BannerClassName, activity, this);
        }

        #region Banner Events
        public event EventHandler<EventArgs> OnAdLoaded;
        public event EventHandler<EventArgs> OnAdOpened;
        public event EventHandler<EventArgs> OnAdClosed;
        public event EventHandler<EventArgs> OnAdClicked;
        public event EventHandler<EventArgs> OnAdLeftApplication;
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;
        #endregion

        #region Banner Methor Implement
        public void CreateBanner(string adUnitId, AdPosition position)
        {
            this.bannerNative.Call("create", new object[2] { adUnitId, (int)position });
        }
        public void LoadBanner()
        {
            this.bannerNative.Call("load");
        }
        public void ShowBanner()
        {
            this.bannerNative.Call("show");
        }
        public void HideBanner()
        {
            this.bannerNative.Call("hide");
        }
        public void DestroyBanner()
        {
            this.bannerNative.Call("destroy");
        }
        public int GetWidthInPixelsBanner()
        {
            return this.bannerNative.Call<int>("getWidthInPixels");
        }
        public int GetHeightInPixelsBanner()
        {
            return this.bannerNative.Call<int>("getHeightInPixels");
        }
        public void SetPositionBanner(AdPosition position)
        {
            this.bannerNative.Call("setPosition", (int)position);
        }
        #endregion

        #region Callbacks from UAdListener
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