
namespace BilMobileAdsUnity.Common
{
    public interface IPBMobileAds
    {
        void Initialize(bool testMode);
        void EnableCOPPA();
        void DisableCOPPA();
        void SetYearOfBirth(int yearOfBirth);
        void SetGender(int gender);
        // Set whether an iOS app should pause when a full screen ad is displayed.
        void SetAppPauseOnBackground(bool pause);
    }
}