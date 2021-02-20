using System;
using BilMobileAdsUnity.Api;

namespace BilMobileAdsUnity.Common
{
    public interface IAdInterstitial
    {
        // Ad event fired when the interstitial ad has been received.
        event EventHandler<EventArgs> OnAdLoaded;
        // Ad event fired when the interstitial ad is opened.
        event EventHandler<EventArgs> OnAdOpened;
        // Ad event fired when the interstitial ad is closed.
        event EventHandler<EventArgs> OnAdClosed;
        // Ad event fired when the interstitial ad is clicked.
        event EventHandler<EventArgs> OnAdClicked;
        /*
        * Called just before the application will background or terminate because the user clicked on an ad
        *               that will launch another application (such as the App Store).
        * */
        event EventHandler<EventArgs> OnAdLeftApplication;
        // Ad event fired when the interstitial ad has failed to load.
        event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

        // Creates a adinterstitial.
        void CreateInterstitial(string adUnitId);

        // Requests a new ad for the interstitial.
        void PreLoadInterstitial();

        // Shows the interstitial on the screen.
        void ShowInterstitial();

        // Destroys a interstitial view.
        void DestroyInterstitial();

        // Check interstitial is Ready to show.
        bool IsReadyInterstitial();

    }
}