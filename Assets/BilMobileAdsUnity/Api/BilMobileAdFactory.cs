using BilMobileAdsUnity.Common;
using UnityEngine;
using UnityEngine.Scripting;

namespace BilMobileAdsUnity
{
    [Preserve]
    public class BilMobileAdFactory : INativeFactory
    {
        public IPBMobileAds PBMobileAdsInstanceNative()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                return BilMobileAdsUnity.Android.PBMobileAdsNative.Instance;
            }
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                return BilMobileAdsUnity.IOS.PBMobileAdsNative.Instance;
            }
            return new BilMobileAdsUnity.Common.MockClass();
        }

        public IAdBanner BuildAdBannerNative()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                return new BilMobileAdsUnity.Android.AdBannerNative();
            }
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                return new BilMobileAdsUnity.IOS.AdBannerNative();
            }
            return new BilMobileAdsUnity.Common.MockClass();
        }

        public IAdInterstitial BuildAdInterstitialNative()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                return new BilMobileAdsUnity.Android.AdInterstitialNative();
            }
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                return new BilMobileAdsUnity.IOS.AdInterstitialNative();
            }
            return new BilMobileAdsUnity.Common.MockClass();
        }

        public IAdRewarded BuildAdRewardedNative()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                return new BilMobileAdsUnity.Android.AdRewardedNative();
            }
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                return new BilMobileAdsUnity.IOS.AdRewardedNative();
            }
            return new BilMobileAdsUnity.Common.MockClass();
        }
    }
}