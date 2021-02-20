//
//  UADTypes.h
//  Unity-iPhone
//
//  Created by HNL_MAC on 11/10/20.
//

/// Positions to place an banner ad.
typedef NS_ENUM(NSUInteger, UADPosition) {
    uAdPositionTopCenterOfScreen = 0,          ///< Top of screen.
    uAdPositionTopLeftOfScreen = 1,      ///< Top left of screen.
    uAdPositionTopRightOfScreen = 2,     ///< Top right of screen.
    uAdPositionBottomCenterOfScreen = 3,       ///< Bottom of screen.
    uAdPositionBottomLeftOfScreen = 4,   ///< Bottom left of screen.
    uAdPositionBottomRightOfScreen = 5,  ///< Bottom right of screen.
    uAdPositionCenterOfScreen = 6        ///< Bottom right of screen.
};

/// Orientation for an banner.
typedef NS_ENUM(NSUInteger, UBannerOrientation) {
    UBannerOrientationCurrent = 0,    ///< Current Orientation.
    UBannerOrientationLandscape = 1,  ///< Landscape.
    UBannerOrientationPortrait = 2,   ///< Portrait.
};

#pragma mark - Banner
/// Type representing a AdBannerUnity Unity Class.
typedef const void *AdBannerNativeTypeRef;

/// Type representing a UADBanner.
typedef const void *UADBannerTypeRef;

/// Callback for when a rewarded ad request was successfully loaded.
typedef void (*UADBannerOnAdLoaded)(AdBannerNativeTypeRef *bannerUnity);

/// Callback for when an rewarded was opened.
typedef void (*UADBannerOnAdOpened)(AdBannerNativeTypeRef *bannerUnity);

/// Callback for when an rewarded was closed.
typedef void (*UADBannerOnAdClosed)(AdBannerNativeTypeRef *bannerUnity);

/// Callback for when an rewarded ad request failed.
typedef void (*UADBannerWillLeaveApplication)(AdBannerNativeTypeRef *bannerUnity);

/// Callback for when an rewarded ad present failed.
typedef void (*UADBannerOnAdFailedToLoad)(AdBannerNativeTypeRef *bannerUnity, const char *error);

#pragma mark - Interstitial
/// Type representing a AdInterstitialUnity Unity Class.
typedef const void *AdInterstitialNativeTypeRef;

/// Type representing a UADInterstitial.
typedef const void *UADInterstitialTypeRef;

/// Callback for when a interstitial ad request was successfully loaded.
typedef void (*UADInterstitialOnAdLoaded)(AdInterstitialNativeTypeRef *interstitialUnity);

/// Callback for when an interstitial was opened.
typedef void (*UADInterstitialOnAdOpened)(AdInterstitialNativeTypeRef *interstitialUnity);

/// Callback for when an interstitial was closed.
typedef void (*UADInterstitialOnAdClosed)(AdInterstitialNativeTypeRef *interstitialUnity);

/// Callback for when an application will background or terminate because of an interstitial click.
typedef void (*UADInterstitialWillLeaveApplication)(AdInterstitialNativeTypeRef *interstitialUnity);

/// Callback for when an interstitial ad request failed.
typedef void (*UADInterstitialOnAdFailedToLoad)(AdInterstitialNativeTypeRef *interstitialUnity, const char *error);

#pragma mark - Rewarded
/// Type representing a AdRewardedUnity Unity Class.
typedef const void *AdRewardedNativeTypeRef;

/// Type representing a UADRewarded.
typedef const void *UADRewardedTypeRef;

/// Callback for when a rewarded ad request was successfully loaded.
typedef void (*UADRewardedOnAdLoaded)(AdRewardedNativeTypeRef *rewardedUnity);

/// Callback for when an rewarded was opened.
typedef void (*UADRewardedOnAdOpened)(AdRewardedNativeTypeRef *rewardedUnity);

/// Callback for when an rewarded was closed.
typedef void (*UADRewardedOnAdClosed)(AdRewardedNativeTypeRef *rewardedUnity);

/// Callback for when an rewarded open completed.
typedef void (*UADRewardedOnUserEarnedReward)(AdRewardedNativeTypeRef *rewardedUnity, const char *type, double amount);

/// Callback for when an rewarded ad request failed.
typedef void (*UADRewardedOnAdFailedToLoad)(AdRewardedNativeTypeRef *rewardedUnity, const char *error);

/// Callback for when an rewarded ad present failed.
typedef void (*UADRewardedOnAdFailedToPresent)(AdRewardedNativeTypeRef *rewardedUnity, const char *error);
