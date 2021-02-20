//
//  UADInterstitial.m
//  UnityFramework
//
//  Created by HNL_MAC on 11/19/20.
//

#import "UADInterstitial.h"

@interface UADInterstitial() <ADInterstitialDelegate>
@end

@implementation UADInterstitial

+ (instancetype)sharedInstance {
    static UADInterstitial *sharedInstance;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        sharedInstance = [[self alloc] init];
    });
    return sharedInstance;
}

- (void)create:(AdInterstitialNativeTypeRef *)interstitialUnity placement:(NSString *)placement {
    _interstitialUnity = interstitialUnity;
    _interstitial = [[ADInterstitial alloc] init:[UPluginUtil getUnityViewController] placement:placement];
    [_interstitial setListener:self];
}

- (void)preload {
    if (![self isPluginReady]) { return; }
    [_interstitial preLoad];
}

- (void)show {
    if (![self isPluginReady]) { return; }
    [_interstitial show];
}

- (void)destroy {
    if (![self isPluginReady]) { return; }
    _interstitial = nil; // -> call deinit class
}

- (BOOL)isReady {
    if (![self isPluginReady]) { return false; }
    return [_interstitial isReady];
}

- (void)dealloc {
    _interstitialUnity = nil;
    _interstitial = nil;
}

- (BOOL) isPluginReady {
    if (!_interstitial) {
        NSLog(@"BilMobileAdsUnity: AdInterstitial is not created");
        return false;
    }
    return true;
}

#pragma mark ADInterstitialDelegate
- (void)interstitialDidFailToPresentScreen {}

- (void)interstitialWillDismissScreen {}

- (void)interstitialDidReceiveAd {
    if (self.adReceivedCallback) {
        self.adReceivedCallback(_interstitialUnity);
    }
}

- (void)interstitialWillPresentScreen {
    if ([UPluginUtil pauseUnityOnBackground]) {
        UnityPause(YES);
    }
    
    if (self.adOpenedCallback) {
        self.adOpenedCallback(_interstitialUnity);
    }
}

- (void)interstitialDidDismissScreen {
    if (UnityIsPaused()) {
        UnityPause(NO);
    }
    
    if (self.adClosedCallback) {
        self.adClosedCallback(_interstitialUnity);
    }
}

- (void)interstitialWillLeaveApplication {
    if (self.willLeaveCallback) {
        self.willLeaveCallback(_interstitialUnity);
    }
}

- (void)interstitialLoadFailWithError:(NSString *)error {
    if (self.adFailedCallback) {
        self.adFailedCallback(_interstitialUnity,  [error cStringUsingEncoding:NSUTF8StringEncoding]);
    }
}

@end
