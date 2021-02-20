using System;
using BilMobileAdsUnity.Api;

namespace BilMobileAdsUnity.Common
{
    public interface IAdRewarded
    {
        // Ad event fired when the rewarded ad has been received.
        event EventHandler<EventArgs> OnAdLoaded;
        // Ad event fired when the rewarded ad is opened.
        event EventHandler<EventArgs> OnAdOpened;
        // Ad event fired when the rewarded ad is closed.
        event EventHandler<EventArgs> OnAdClosed;
        // Ad event fired when the rewarded ad has rewarded the user.
        event EventHandler<ADRewardItem> OnUserEarnedReward;
        // Ad event fired when the rewarded ad has failed to load.
        event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;
        // Ad event fired when the rewarded ad has failed to show.
        event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToShow;

        // Creates a rewarded and adds it to the view hierarchy.
        void CreateRewarded(string adUnitId);

        // Requests a new ad for the rewarded.
        void PreLoadRewarded();

        // Shows the rewarded on the screen.
        void ShowRewarded();

        // Destroys a rewarded view.
        void DestroyRewarded();

        // Check rewarded is Ready to show.
        bool IsReadyRewarded();

    }
}