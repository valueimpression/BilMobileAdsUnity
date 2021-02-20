using System;
using BilMobileAdsUnity.Common;

namespace BilMobileAdsUnity.Api
{
    public class AdInterstitial
    {
        private IAdInterstitial native;

        public AdInterstitial(string adUnitId)
        {
            this.native = PBMobileAds.GetFactory().BuildAdInterstitialNative();
            this.native.CreateInterstitial(adUnitId);
            ConfigureEvents();
        }

        public event EventHandler<EventArgs> OnAdLoaded;
        public event EventHandler<EventArgs> OnAdOpened;
        public event EventHandler<EventArgs> OnAdClosed;
        public event EventHandler<EventArgs> OnAdClicked;
        public event EventHandler<EventArgs> OnAdLeftApplication;
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

        public void PreLoad()
        {
            this.native.PreLoadInterstitial();
        }

        public void Show()
        {
            this.native.ShowInterstitial();
        }

        public void Destroy()
        {
            this.native.DestroyInterstitial();
        }

        public bool IsReady()
        {
            return this.native.IsReadyInterstitial();
        }

        private void ConfigureEvents()
        {
            this.native.OnAdLoaded += (sender, args) =>
            {
                if (this.OnAdLoaded != null)
                {
                    this.OnAdLoaded(this, args);
                }
            };
            this.native.OnAdOpened += (sender, args) =>
            {
                if (this.OnAdOpened != null)
                {
                    this.OnAdOpened(this, args);
                }
            };
            this.native.OnAdClosed += (sender, args) =>
            {
                if (this.OnAdClosed != null)
                {
                    this.OnAdClosed(this, args);
                }
            };
            this.native.OnAdClicked += (sender, args) =>
            {
                if (this.OnAdClicked != null)
                {
                    this.OnAdClicked(this, args);
                }
            };
            this.native.OnAdLeftApplication += (sender, args) =>
            {
                if (this.OnAdLeftApplication != null)
                {
                    this.OnAdLeftApplication(this, args);
                }
            };
            this.native.OnAdFailedToLoad += (sender, args) =>
            {
                if (this.OnAdFailedToLoad != null)
                {
                    this.OnAdFailedToLoad(this, args);
                }
            };
        }
    }
}