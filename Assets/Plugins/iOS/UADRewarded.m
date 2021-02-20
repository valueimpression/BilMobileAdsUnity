//
//  UADRewarded.m
//  UnityFramework
//
//  Created by HNL_MAC on 11/20/20.
//

#import "UADRewarded.h"

@interface UADRewarded() <ADRewardedDelegate>
@end

@implementation UADRewarded

+ (instancetype)sharedInstance {
    static UADRewarded *sharedInstance;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        sharedInstance = [[self alloc] init];
    });
    return sharedInstance;
}

- (void)create:(AdRewardedNativeTypeRef *)rewardedUnity placement:(NSString *)placement {
    _rewardedUnity = rewardedUnity;
    _rewarded = [[ADRewarded alloc] init:[UPluginUtil getUnityViewController] placement:placement];
    [_rewarded setListener:self];
}

- (void)preload {
    if (![self isPluginReady]) { return; }
    [_rewarded preLoad];
}

- (void)show {
    if (![self isPluginReady]) { return; }
    [_rewarded show];
}

- (void)destroy {
    if (![self isPluginReady]) { return; }
    _rewarded = nil; // -> call deinit class
}

- (BOOL)isReady {
    if (![self isPluginReady]) { return false; }
    return [_rewarded isReady];
}

- (void)dealloc {
    _rewardedUnity = nil;
    _rewarded = nil;
}

- (BOOL) isPluginReady {
    if (!_rewarded) {
        NSLog(@"BilMobileAdsUnity: AdRewarded is not created");
        return false;
    }
    return true;
}

#pragma mark ADRewardedDelegate
- (void)rewardedDidReceiveAd {
    if (self.adReceivedCallback) {
        self.adReceivedCallback(_rewardedUnity);
    }
}
- (void)rewardedDidPresent {
    if ([UPluginUtil pauseUnityOnBackground]) {
        UnityPause(YES);
    }
    
    if (self.adOpenedCallback) {
        self.adOpenedCallback(_rewardedUnity);
    }
}

- (void)rewardedDidDismiss {
    if (UnityIsPaused()) {
        UnityPause(NO);
    }
    
    if (self.adClosedCallback) {
        self.adClosedCallback(_rewardedUnity);
    }
}

- (void)rewardedUserDidEarnWithRewardedItem:(ADRewardedItem *)rewardedItem {
    if (self.adUserEarnedReward) {
        self.adUserEarnedReward(_rewardedUnity, [[rewardedItem getType] cStringUsingEncoding:NSUTF8StringEncoding], [rewardedItem getAmount].doubleValue);
    }
}

- (void)rewardedFailToLoadWithError:(NSString *)error {
    if (self.adFailedToLoadCallback) {
        self.adFailedToLoadCallback(_rewardedUnity, [error cStringUsingEncoding:NSUTF8StringEncoding]);
    }
}

- (void)rewardedFailToPresentWithError:(NSString *)error {
    if (self.adFailedToPresentCallback) {
        self.adFailedToPresentCallback(_rewardedUnity, [error cStringUsingEncoding:NSUTF8StringEncoding]);
    }
}

@end
