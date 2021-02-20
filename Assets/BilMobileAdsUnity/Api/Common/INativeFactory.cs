using BilMobileAdsUnity.Common;

namespace BilMobileAdsUnity
{
    public interface INativeFactory
    {
        IAdBanner BuildAdBannerNative();

        IAdInterstitial BuildAdInterstitialNative();

        IAdRewarded BuildAdRewardedNative();

        IPBMobileAds PBMobileAdsInstanceNative();
    }
}