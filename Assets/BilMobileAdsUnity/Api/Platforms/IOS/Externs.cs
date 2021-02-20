using System;
using System.Runtime.InteropServices;
using BilMobileAdsUnity.Api;
using BilMobileAdsUnity.IOS;

namespace GoogleMobileAds.IOS
{
    // Externs used by the IOS component.
    internal class Externs
    {
        #region PBMobileAds: 
        [DllImport("__Internal")]
        internal static extern void UPBMobileAdsInitialize(bool testMode);
        [DllImport("__Internal")]
        internal static extern void UPBMobileAdsEnableCOPPA();
        [DllImport("__Internal")]
        internal static extern void UPBMobileAdsDisableCOPPA();
        [DllImport("__Internal")]
        internal static extern void UPBMobileAdsSetGender(int gender);
        [DllImport("__Internal")]
        internal static extern void UPBMobileAdsSetYearOfBirth(int yearOfBirth);
        [DllImport("__Internal")]
        internal static extern void USetAppPauseOnBackground(bool pause);
        #endregion

        #region Banner: 
        [DllImport("__Internal")]
        internal static extern IntPtr UADBannerCreate(IntPtr bannerUnity, string adUnitId, int position);
        [DllImport("__Internal")]
        internal static extern void UADBannerSetCallbacks(
            IntPtr bannerNative,
            AdBannerNative.UADBannerOnAdLoaded adReceivedCallback,
            AdBannerNative.UADBannerOnAdOpened adOpenedCallback,
            AdBannerNative.UADBannerOnAdClosed adClosedCallback,
            AdBannerNative.UADBannerWillLeaveApplication willLeaveCallback,
            AdBannerNative.UADBannerOnAdFailedToLoad adFailedCallback
        );
        [DllImport("__Internal")]
        internal static extern void UADBannerLoad(IntPtr bannerNative);
        [DllImport("__Internal")]
        internal static extern void UADBannerShow(IntPtr bannerNative);
        [DllImport("__Internal")]
        internal static extern void UADBannerHide(IntPtr bannerNative);
        [DllImport("__Internal")]
        internal static extern void UADBannerDestroy(IntPtr bannerNative);
        [DllImport("__Internal")]
        internal static extern int UADBannerGetWidthInPixels(IntPtr bannerNative);
        [DllImport("__Internal")]
        internal static extern int UADBannerGetHeightInPixels(IntPtr bannerNative);
        [DllImport("__Internal")]
        internal static extern void UADBannerSetPosition(IntPtr bannerNative, int position);
        #endregion

        #region Interstitial: 
        [DllImport("__Internal")]
        internal static extern IntPtr UADInterstitialCreate(IntPtr interstitialUnity, string adUnitId);
        [DllImport("__Internal")]
        internal static extern void UADInterstitialSetCallbacks(
            IntPtr interstitialNative,
            AdInterstitialNative.UADInterstitialOnAdLoaded adReceivedCallback,
            AdInterstitialNative.UADInterstitialOnAdOpened adOpenedCallback,
            AdInterstitialNative.UADInterstitialOnAdClosed adClosedCallback,
            AdInterstitialNative.UADInterstitialWillLeaveApplication willLeaveCallback,
            AdInterstitialNative.UADInterstitialOnAdFailedToLoad adFailedCallback
        );
        [DllImport("__Internal")]
        internal static extern void UADInterstitialPreload(IntPtr interstitialNative);
        [DllImport("__Internal")]
        internal static extern void UADInterstitialShow(IntPtr interstitialNative);
        [DllImport("__Internal")]
        internal static extern void UADInterstitialDestroy(IntPtr interstitialNative);
        [DllImport("__Internal")]
        internal static extern bool UADInterstitialIsReady(IntPtr interstitialNative);
        #endregion

        #region Rewarded: 
        [DllImport("__Internal")]
        internal static extern IntPtr UADRewardedCreate(IntPtr rewardedUnity, string adUnitId);
        [DllImport("__Internal")]
        internal static extern void UADRewardedSetCallbacks(
            IntPtr rewardedNative,
            AdRewardedNative.UADRewardedOnAdLoaded adReceivedCallback,
            AdRewardedNative.UADRewardedOnAdOpened adOpenedCallback,
            AdRewardedNative.UADRewardedOnAdClosed adClosedCallback,
            AdRewardedNative.UADRewardedOnUserEarnedReward adUserEarnedReward,
            AdRewardedNative.UADRewardedOnAdFailedToLoad adFailedToLoadCallback,
            AdRewardedNative.UADRewardedOnAdFailedToPresent adFailedToPresentCallback
        );
        [DllImport("__Internal")]
        internal static extern void UADRewardedPreload(IntPtr rewardedNative);
        [DllImport("__Internal")]
        internal static extern void UADRewardedShow(IntPtr rewardedNative);
        [DllImport("__Internal")]
        internal static extern void UADRewardedDestroy(IntPtr rewardedNative);
        [DllImport("__Internal")]
        internal static extern bool UADRewardedIsReady(IntPtr rewardedNative);
        #endregion
    }
}