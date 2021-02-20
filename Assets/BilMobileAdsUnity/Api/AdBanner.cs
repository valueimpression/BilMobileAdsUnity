using System;
using BilMobileAdsUnity.Common;
using UnityEngine;

namespace BilMobileAdsUnity.Api
{
    public class AdBanner
    {
        private IAdBanner native;

        public AdBanner(string adUnitId, AdPosition position)
        {
            this.native = PBMobileAds.GetFactory().BuildAdBannerNative();
            native.CreateBanner(adUnitId, position);
            ConfigureEvents();
        }

        public event EventHandler<EventArgs> OnAdLoaded;
        public event EventHandler<EventArgs> OnAdOpened;
        public event EventHandler<EventArgs> OnAdClosed;
        public event EventHandler<EventArgs> OnAdClicked;
        public event EventHandler<EventArgs> OnAdLeftApplication;
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

        public void Load()
        {
            this.native.LoadBanner();
        }

        public void Show()
        {
            this.native.ShowBanner();
        }

        public void Hide()
        {
            this.native.HideBanner();
        }

        public void Destroy()
        {
            this.native.DestroyBanner();
        }

        public void SetPosition(AdPosition adPosition)
        {
            this.native.SetPositionBanner(adPosition);
        }

        public float GetWidthInPixels()
        {
            return this.native.GetWidthInPixelsBanner();
        }

        public float GetHeightInPixels()
        {
            return this.native.GetHeightInPixelsBanner();
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