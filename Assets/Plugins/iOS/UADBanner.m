//
//  UADBanner.m
//  UnityFramework
//
//  Created by HNL_MAC on 11/21/20.
//

#import "UADBanner.h"

@interface UADBanner() <ADBannerDelegate>

/// Defines where the ad should be positioned on the screen with a GADAdPosition.
@property(nonatomic, assign) UADPosition adPosition;

@end

@implementation UADBanner

+ (instancetype)sharedInstance {
    static UADBanner *sharedInstance;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        sharedInstance = [[self alloc] init];
    });
    return sharedInstance;
}

- (void)create:(AdBannerNativeTypeRef _Nonnull *)bannerUnity placement:(NSString *)placement position:(int)position {
    _bannerUnity = bannerUnity;
    
    _adPosition = position;
    UIViewController *uvCtrl = [UPluginUtil getUnityViewController];
    _banner = [[ADBanner alloc] init:uvCtrl view:uvCtrl.view placement:placement];
    [_banner setListener:self];
    [_banner isDisSetupAnchor:true];
    
}

- (void)load {
    if (![self isPluginReady]) { return; }
    [_banner load];
}

- (void)show {
    if (![self isPluginReady]) { return; }
    [_banner getADView].hidden = NO;
    [_banner startFetchData];
}

- (void)hide {
    if (![self isPluginReady]) { return; }
    [_banner getADView].hidden = YES;
    [_banner stopFetchData];
}

- (CGFloat)getWidthInPixels {
    if (![self isPluginReady]) { return 0; }
    return CGRectGetWidth(CGRectStandardize([_banner getADView].frame)) * [UIScreen mainScreen].scale;
}

- (CGFloat)getHeightInPixels {
    if (![self isPluginReady]) { return 0; }
    return CGRectGetHeight(CGRectStandardize([_banner getADView].frame)) * [UIScreen mainScreen].scale;
}

- (void)setPosition:(int)position {
    if (![self isPluginReady]) { return; }
    
    _adPosition = position;
    [self positionBannerView];
}

- (void)destroy {
    if (![self isPluginReady]) { return; }
    _banner = nil; // -> call deinit class
}

- (void)dealloc {
    _bannerUnity = nil;
    _banner = nil;
}

- (void)positionBannerView {
    [_banner setAnchorWithAnchor:_adPosition];
    
    UIView *unityView = [UPluginUtil getUnityViewController].view;
    [UPluginUtil positionView:[_banner getADView] inParentView:unityView adPosition:_adPosition];
}

- (BOOL) isPluginReady {
    if (!_banner) {
        NSLog(@"BilMobileAdsUnity: AdBanner is not created");
        return false;
    }
    return true;
}

#pragma mark ADBannerDelegate
- (void)bannerDidReceiveAd{
    [self positionBannerView];
    
    if (self.adReceivedCallback) {
        self.adReceivedCallback(_bannerUnity);
    }
}
- (void)bannerWillPresentScreen {
    if (self.adOpenedCallback) {
        self.adOpenedCallback(_bannerUnity);
    }
}
- (void)bannerWillDismissScreen{}

- (void)bannerDidDismissScreen {
    if (self.adClosedCallback) {
        self.adClosedCallback(_bannerUnity);
    }
}

- (void)bannerWillLeaveApplication {
    if (self.willLeaveCallback) {
        self.willLeaveCallback(_bannerUnity);
    }
}

- (void)bannerLoadFailWithError:(NSString *)error {
    if (self.adFailedCallback) {
        self.adFailedCallback(_bannerUnity, [error cStringUsingEncoding:NSUTF8StringEncoding]);
    }
}

@end
