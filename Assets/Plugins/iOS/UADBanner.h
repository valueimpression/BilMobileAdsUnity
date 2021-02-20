//
//  UADBanner.h
//  UnityFramework
//
//  Created by HNL_MAC on 11/21/20.
//

#import <Foundation/Foundation.h>
#import "UPluginUtil.h"
#import "UADTypes.h"

@import BilMobileAds;

@interface UADBanner : NSObject

@property(nonatomic, strong) ADBanner * _Nonnull banner;

@property(nonatomic, assign) AdBannerNativeTypeRef _Nonnull * _Nonnull bannerUnity;

+ (nonnull instancetype)sharedInstance;

- (void) create:(AdBannerNativeTypeRef _Nonnull *_Nonnull)bannerUnity placement:(NSString *_Nonnull)placement position:(int) position;

- (void) load;

- (void) show;

- (void) hide;

- (void) destroy;

- (void) setPosition:(int)position;

@property(nonatomic, readonly) CGFloat getWidthInPixels;
@property(nonatomic, readonly) CGFloat getHeightInPixels;
@property(nonatomic, assign) UADBannerOnAdLoaded _Nullable adReceivedCallback;
@property(nonatomic, assign) UADBannerOnAdOpened _Nullable adOpenedCallback;
@property(nonatomic, assign) UADBannerOnAdClosed _Nullable adClosedCallback;
@property(nonatomic, assign) UADBannerWillLeaveApplication _Nullable willLeaveCallback;
@property(nonatomic, assign) UADBannerOnAdFailedToLoad _Nullable adFailedCallback;

@end

