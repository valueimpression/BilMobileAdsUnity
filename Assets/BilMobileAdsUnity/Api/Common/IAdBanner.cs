using System;
using BilMobileAdsUnity.Api;

namespace BilMobileAdsUnity.Common
{
    public interface IAdBanner
    {
        // Ad event fired when the banner ad has been received.
        event EventHandler<EventArgs> OnAdLoaded;
        // Ad event fired when the banner ad is opened.
        event EventHandler<EventArgs> OnAdOpened;
        // Ad event fired when the banner ad is closed.
        event EventHandler<EventArgs> OnAdClosed;
        // Ad event fired when the banner ad is clicked.
        event EventHandler<EventArgs> OnAdClicked;
        /*
        * Called just before the application will background or terminate because the user clicked on an ad
        *               that will launch another application (such as the App Store).
        * */
        event EventHandler<EventArgs> OnAdLeftApplication;
        // Ad event fired when the banner ad has failed to load.
        event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

        // Creates a banner view and adds it to the view hierarchy.
        void CreateBanner(string adUnitId, AdPosition position);

        // Requests a new ad for the banner view.
        void LoadBanner();

        // Shows the banner view on the screen.
        void ShowBanner();

        // Hide the banner view from the screen.
        void HideBanner();

        // Destroys a banner view.
        void DestroyBanner();

        // Returns the width of the Banner in pixels.
        int GetWidthInPixelsBanner();

        // Returns the height of the Banner in pixels.
        int GetHeightInPixelsBanner();

        // Set the position of the banner view using standard position.
        void SetPositionBanner(AdPosition adPosition);

    }
}