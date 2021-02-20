//
//  UPluginUtil.h
//  UnityFramework
//
//  Created by HNL_MAC on 11/19/20.
//

#import <Foundation/Foundation.h>
#import <GoogleMobileAds/GADAdSize.h>
#import "UADTypes.h"

@interface UPluginUtil : NSObject

/// Whether the Unity app should be paused when a full screen ad is displayed.
@property(class) BOOL pauseUnityOnBackground;

/// Returns the Unity view controller.
+ (UIViewController *)getUnityViewController;

/// If requesting smart banner landscape, returns the custom size for landscape smart banners which
/// is full width of the safe area and auto height. Assumes that the application window is visible.
/// If requesting any other ad size, returns the un-modified ad size.
+ (GADAdSize)safeAdSizeForAdSize:(GADAdSize)adSize;

/// Position view in the parent view, corresponding to the adPosition.
+ (void)positionView:(UIView *)view inParentView:(UIView *)parentView adPosition:(UADPosition)adPosition;

@end
