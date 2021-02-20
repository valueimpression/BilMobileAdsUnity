//
//  UInterface.m
//  Unity-iPhone
//
//  Created by HNL_MAC on 11/10/20.
//
#import "UADTypes.h"
#import "UADBanner.h"
#import "UADInterstitial.h"
#import "UADRewarded.h"


@import BilMobileAds;

@class ADInterstitialDelegate;

// MARK: - PBMobileAds
void UPBMobileAdsInitialize(bool testMode) {
    [[PBMobileAds shared] initializeWithTestMode:testMode];
}
void UPBMobileAdsEnableCOPPA() {
    [[PBMobileAds shared] enableCOPPA];
}
void UPBMobileAdsDisableCOPPA() {
    [[PBMobileAds shared] disableCOPPA];
}
void UPBMobileAdsSetGender(int gender) {
    switch (gender) {
        case 0:
            [[PBMobileAds shared] setGenderWithGender:GenderUnknown];
            break;
        case 1:
            [[PBMobileAds shared] setGenderWithGender:GenderMale];
            break;
        case 2:
            [[PBMobileAds shared] setGenderWithGender:GenderFemale];
            break;
    }
}
void UPBMobileAdsSetYearOfBirth(int yearOfBirth) {
    [[PBMobileAds shared] setYearOfBirthWithYob:yearOfBirth];
}
/// Indicates if the Unity app should be paused when a full screen ad (interstitial or rewarded ad) is displayed.
void USetAppPauseOnBackground(BOOL pause) { [UPluginUtil setPauseUnityOnBackground:pause]; }

// MARK: - Banner
/// Creates a UADBannerTypeRef and returns its reference.
UADBannerTypeRef UADBannerCreate(AdBannerNativeTypeRef *bannerUnity, const char *placement, int position) {
    UADBanner *banner = [UADBanner sharedInstance];
    [banner create:bannerUnity placement:[NSString stringWithUTF8String:placement] position: position];
    return (__bridge UADBannerTypeRef) banner;
}
/// Sets the banner callback methods to be invoked during banner ad events.
void UADBannerSetCallbacks(UADBannerTypeRef bannerTypeRef,
                               UADBannerOnAdLoaded adReceivedCallback,
                               UADBannerOnAdOpened adOpenedCallback,
                               UADBannerOnAdClosed adClosedCallback,
                               UADBannerWillLeaveApplication willLeaveCallback,
                               UADBannerOnAdFailedToLoad adFailedCallback) {
    UADBanner *bannerNative = (__bridge UADBanner *)bannerTypeRef;
    bannerNative.adReceivedCallback = adReceivedCallback;
    bannerNative.adOpenedCallback = adOpenedCallback;
    bannerNative.adClosedCallback = adClosedCallback;
    bannerNative.willLeaveCallback = willLeaveCallback;
    bannerNative.adFailedCallback = adFailedCallback;
}
void UADBannerLoad(UADBannerTypeRef bannerTypeRef) {
    UADBanner *bannerNative = (__bridge UADBanner *)bannerTypeRef;
    [bannerNative load];
}
void UADBannerShow(UADBannerTypeRef bannerTypeRef) {
    UADBanner *bannerNative = (__bridge UADBanner *)bannerTypeRef;
    [bannerNative show];
}
void UADBannerHide(UADBannerTypeRef bannerTypeRef) {
    UADBanner *bannerNative = (__bridge UADBanner *)bannerTypeRef;
    [bannerNative hide];
}
void UADBannerDestroy(UADBannerTypeRef bannerTypeRef) {
    UADBanner *bannerNative = (__bridge UADBanner *)bannerTypeRef;
    [bannerNative destroy];
}
int UADBannerGetWidthInPixels(UADBannerTypeRef bannerTypeRef) {
    UADBanner *bannerNative = (__bridge UADBanner *)bannerTypeRef;
    return (int)bannerNative.getWidthInPixels;
}
int UADBannerGetHeightInPixels(UADBannerTypeRef bannerTypeRef) {
    UADBanner *bannerNative = (__bridge UADBanner *)bannerTypeRef;
    return (int)bannerNative.getHeightInPixels;
}
void UADBannerSetPosition(UADBannerTypeRef bannerTypeRef, int position) {
    UADBanner *bannerNative = (__bridge UADBanner *)bannerTypeRef;
    [bannerNative setPosition:position];
}

// MARK: - Interstitial
/// Creates a UADInterstitialTypeRef and returns its reference.
UADInterstitialTypeRef UADInterstitialCreate(AdInterstitialNativeTypeRef *interstitialUnity, const char *placement) {
    UADInterstitial *interstitial = [UADInterstitial sharedInstance];
    [interstitial create:interstitialUnity placement:[NSString stringWithUTF8String:placement]];
    return (__bridge UADInterstitialTypeRef) interstitial;
}
/// Sets the interstitial callback methods to be invoked during interstitial ad events.
void UADInterstitialSetCallbacks(UADInterstitialTypeRef interstitialTypeRef,
                                    UADInterstitialOnAdLoaded adReceivedCallback,
                                    UADInterstitialOnAdOpened adOpenedCallback,
                                    UADInterstitialOnAdClosed adClosedCallback,
                                    UADInterstitialWillLeaveApplication willLeaveCallback,
                                    UADInterstitialOnAdFailedToLoad adFailedCallback) {
    UADInterstitial *interstitialNative = (__bridge UADInterstitial *)interstitialTypeRef;
    interstitialNative.adReceivedCallback = adReceivedCallback;
    interstitialNative.adOpenedCallback = adOpenedCallback;
    interstitialNative.adClosedCallback = adClosedCallback;
    interstitialNative.willLeaveCallback = willLeaveCallback;
    interstitialNative.adFailedCallback = adFailedCallback;
}
void UADInterstitialPreload(UADInterstitialTypeRef interstitialTypeRef) {
    UADInterstitial *interstitialNative = (__bridge UADInterstitial *)interstitialTypeRef;
    [interstitialNative preload];
}
void UADInterstitialShow(UADInterstitialTypeRef interstitialTypeRef) {
    UADInterstitial *interstitialNative = (__bridge UADInterstitial *)interstitialTypeRef;
    [interstitialNative show];
}
void UADInterstitialDestroy(UADInterstitialTypeRef interstitialTypeRef) {
    UADInterstitial *interstitialNative = (__bridge UADInterstitial *)interstitialTypeRef;
    [interstitialNative destroy];
}
BOOL UADInterstitialIsReady(UADInterstitialTypeRef interstitialTypeRef) {
    UADInterstitial *interstitialNative = (__bridge UADInterstitial *)interstitialTypeRef;
    return [interstitialNative isReady];
}

// MARK: - Rewarded
/// Creates a UADRewardedTypeRef and returns its reference.
UADRewardedTypeRef UADRewardedCreate(AdInterstitialNativeTypeRef *interstitialUnity, const char *placement) {
    UADRewarded *rewared = [UADRewarded sharedInstance];
    [rewared create:interstitialUnity placement:[NSString stringWithUTF8String:placement]];
    return (__bridge UADRewardedTypeRef) rewared;
}
/// Sets the rewarded callback methods to be invoked during rewarded ad events.
void UADRewardedSetCallbacks(UADRewardedTypeRef rewardedTypeRef,
                                UADRewardedOnAdLoaded adReceivedCallback,
                                UADRewardedOnAdOpened adOpenedCallback,
                                UADRewardedOnAdClosed adClosedCallback,
                                UADRewardedOnUserEarnedReward adUserEarnedReward,
                                UADRewardedOnAdFailedToLoad adFailedToLoadCallback,
                                UADRewardedOnAdFailedToPresent adFailedToPresentCallback) {
    UADRewarded *rewardedNative = (__bridge UADRewarded *)rewardedTypeRef;
    rewardedNative.adReceivedCallback = adReceivedCallback;
    rewardedNative.adOpenedCallback = adOpenedCallback;
    rewardedNative.adClosedCallback = adClosedCallback;
    rewardedNative.adUserEarnedReward = adUserEarnedReward;
    rewardedNative.adFailedToLoadCallback = adFailedToLoadCallback;
    rewardedNative.adFailedToPresentCallback = adFailedToPresentCallback;
}
void UADRewardedPreload(UADRewardedTypeRef rewardedTypeRef) {
    UADRewarded *rewardedNative = (__bridge UADRewarded *)rewardedTypeRef;
    [rewardedNative preload];
}
void UADRewardedShow(UADRewardedTypeRef rewardedTypeRef) {
    UADRewarded *rewardedNative = (__bridge UADRewarded *)rewardedTypeRef;
    [rewardedNative show];
}
void UADRewardedDestroy(UADRewardedTypeRef rewardedTypeRef) {
    UADRewarded *rewardedNative = (__bridge UADRewarded *)rewardedTypeRef;
    [rewardedNative destroy];
}
BOOL UADRewardedIsReady(UADRewardedTypeRef rewardedTypeRef) {
    UADRewarded *rewardedNative = (__bridge UADRewarded *)rewardedTypeRef;
    return [rewardedNative isReady];
}
