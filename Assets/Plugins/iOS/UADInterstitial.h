//
//  UADInterstitial.h
//  UnityFramework
//
//  Created by HNL_MAC on 11/19/20.
//

#import <Foundation/Foundation.h>
#import "UPluginUtil.h"
#import "UADTypes.h"

@import BilMobileAds;

@interface UADInterstitial : NSObject

@property(nonatomic, strong) ADInterstitial * _Nonnull interstitial;

@property(nonatomic, assign) AdInterstitialNativeTypeRef _Nonnull * _Nonnull interstitialUnity;

+ (nonnull instancetype)sharedInstance;

- (void) create:(AdInterstitialNativeTypeRef _Nonnull *_Nonnull)interstitialUnity placement:(NSString *_Nonnull)placement;

- (void) preload;

- (void) show;

- (void) destroy;

- (BOOL) isReady;

@property(nonatomic, assign) UADInterstitialOnAdLoaded _Nullable adReceivedCallback;
@property(nonatomic, assign) UADInterstitialOnAdOpened _Nullable adOpenedCallback;
@property(nonatomic, assign) UADInterstitialOnAdClosed _Nullable adClosedCallback;
@property(nonatomic, assign) UADInterstitialWillLeaveApplication _Nullable willLeaveCallback;
@property(nonatomic, assign) UADInterstitialOnAdFailedToLoad _Nullable adFailedCallback;

@end
