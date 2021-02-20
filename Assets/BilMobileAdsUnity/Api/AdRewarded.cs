using System;
using BilMobileAdsUnity.Common;

namespace BilMobileAdsUnity.Api
{
    public class AdRewarded
    {
        private IAdRewarded native;

        public AdRewarded(string adUnitId)
        {
            this.native = PBMobileAds.GetFactory().BuildAdRewardedNative();
            this.native.CreateRewarded(adUnitId);
            ConfigureEvents();
        }

        public event EventHandler<EventArgs> OnAdLoaded;
        public event EventHandler<EventArgs> OnAdOpened;
        public event EventHandler<EventArgs> OnAdClosed;
        public event EventHandler<ADRewardItem> OnUserEarnedReward;
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToShow;

        public void PreLoad()
        {
            this.native.PreLoadRewarded();
        }

        public void Show()
        {
            this.native.ShowRewarded();
        }

        public void Destroy()
        {
            this.native.DestroyRewarded();
        }

        public bool IsReady()
        {
            return this.native.IsReadyRewarded();
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
            this.native.OnUserEarnedReward += (sender, args) =>
            {
                if (this.OnUserEarnedReward != null)
                {
                    this.OnUserEarnedReward(this, args);
                }
            };
            this.native.OnAdFailedToLoad += (sender, args) =>
            {
                if (this.OnAdFailedToLoad != null)
                {
                    this.OnAdFailedToLoad(this, args);
                }
            };
            this.native.OnAdFailedToShow += (sender, args) =>
            {
                if (this.OnAdFailedToShow != null)
                {
                    this.OnAdFailedToShow(this, args);
                }
            };
        }
    }
}