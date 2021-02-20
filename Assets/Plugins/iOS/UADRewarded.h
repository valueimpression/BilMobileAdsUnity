//
//  UADRewarded.h
//  UnityFramework
//
//  Created by HNL_MAC on 11/20/20.
//

#import <Foundation/Foundation.h>
#import "UPluginUtil.h"
#import "UADTypes.h"

@import BilMobileAds;

@interface UADRewarded : NSObject

@property(nonatomic, strong) ADRewarded * _Nonnull rewarded;

@property(nonatomic, assign) AdRewardedNativeTypeRef _Nonnull * _Nonnull rewardedUnity;

+ (nonnull instancetype)sharedInstance;

- (void) create:(AdRewardedNativeTypeRef _Nonnull *_Nonnull)rewardedUnity placement:(NSString *_Nonnull)placement;

- (void) preload;

- (void) show;

- (void) destroy;

- (BOOL) isReady;

@property(nonatomic, assign) UADRewardedOnAdLoaded _Nullable adReceivedCallback;
@property(nonatomic, assign) UADRewardedOnAdOpened _Nullable adOpenedCallback;
@property(nonatomic, assign) UADRewardedOnAdClosed _Nullable adClosedCallback;
@property(nonatomic, assign) UADRewardedOnUserEarnedReward _Nullable adUserEarnedReward;
@property(nonatomic, assign) UADRewardedOnAdFailedToLoad _Nullable adFailedToLoadCallback;
@property(nonatomic, assign) UADRewardedOnAdFailedToPresent _Nullable adFailedToPresentCallback;

@end
