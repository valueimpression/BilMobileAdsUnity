//
//  UPluginUtil.m
//  UnityFramework
//
//  Created by HNL_MAC on 11/19/20.
//

#import "UPluginUtil.h"
#import "UnityAppController.h"

@implementation UPluginUtil

static BOOL _pauseUnityOnBackground = NO;
+ (BOOL)pauseUnityOnBackground {
  return _pauseUnityOnBackground;
}
+ (void)setPauseUnityOnBackground:(BOOL)pause {
    _pauseUnityOnBackground = pause;
}

+ (UIViewController *) getUnityViewController {
    return ((UnityAppController *)[UIApplication sharedApplication].delegate).rootViewController;;
}

BOOL isOperatingSystemAtLeastVersion(NSInteger majorVersion) {
    NSProcessInfo *processInfo = NSProcessInfo.processInfo;
    if ([processInfo respondsToSelector:@selector(isOperatingSystemAtLeastVersion:)]) {
        NSOperatingSystemVersion version = {majorVersion};
        return [processInfo isOperatingSystemAtLeastVersion:version];
    } else {
        return majorVersion >= 7;
    }
}

static CGFloat safeWidthLandscape(void) {
    CGRect screenBounds = [UIScreen mainScreen].bounds;
    if (isOperatingSystemAtLeastVersion(11)) {
        CGRect safeFrame = [UIApplication sharedApplication].keyWindow.safeAreaLayoutGuide.layoutFrame;
        if (!CGSizeEqualToSize(safeFrame.size, CGSizeZero)) {
            screenBounds = safeFrame;
        }
    }
    return MAX(CGRectGetWidth(screenBounds), CGRectGetHeight(screenBounds));
}

+ (GADAdSize)safeAdSizeForAdSize:(GADAdSize)adSize {
    if (isOperatingSystemAtLeastVersion(11) &&
        GADAdSizeEqualToSize(kGADAdSizeSmartBannerLandscape, adSize)) {
        CGSize usualSize = CGSizeFromGADAdSize(kGADAdSizeSmartBannerLandscape);
        CGSize bannerSize = CGSizeMake(safeWidthLandscape(), usualSize.height);
        return GADAdSizeFromCGSize(bannerSize);
    } else {
        return adSize;
    }
}

+ (void)positionView:(UIView *)view
        inParentView:(UIView *)parentView
          adPosition:(UADPosition)adPosition {
    CGRect parentBounds = parentView.bounds;
    if (isOperatingSystemAtLeastVersion(11)) {
        CGRect safeAreaFrame = parentView.safeAreaLayoutGuide.layoutFrame;
        if (!CGSizeEqualToSize(CGSizeZero, safeAreaFrame.size)) {
            parentBounds = safeAreaFrame;
        }
    }
    CGFloat top = CGRectGetMinY(parentBounds) + CGRectGetMidY(view.bounds);
    CGFloat left = CGRectGetMinX(parentBounds) + CGRectGetMidX(view.bounds);
    
    CGFloat bottom = CGRectGetMaxY(parentBounds) - CGRectGetMidY(view.bounds);
    CGFloat right = CGRectGetMaxX(parentBounds) - CGRectGetMidX(view.bounds);
    CGFloat centerX = CGRectGetMidX(parentBounds);
    CGFloat centerY = CGRectGetMidY(parentBounds);
    
    /// If this view is of greater or equal width to the parent view, do not offset
    /// to edge of safe area. Eg for smart banners that are still full screen width.
    if (CGRectGetWidth(view.bounds) >= CGRectGetWidth(parentView.bounds)) {
        left = CGRectGetMidX(parentView.bounds);
    }
    
    /// Similarly for height, if view is of custom size which is full screen height, do not offset.
    if (CGRectGetHeight(view.bounds) >= CGRectGetHeight(parentView.bounds)) {
        top = CGRectGetMidY(parentView.bounds);
    }
    
    CGPoint center = CGPointMake(centerX, top);
    switch (adPosition) {
        case uAdPositionTopCenterOfScreen:
            center = CGPointMake(centerX, top);
            break;
        case uAdPositionTopLeftOfScreen:
            center = CGPointMake(left, top);
            break;
        case uAdPositionTopRightOfScreen:
            center = CGPointMake(right, top);
            break;
        case uAdPositionBottomCenterOfScreen:
            center = CGPointMake(centerX, bottom);
            break;
        case uAdPositionBottomLeftOfScreen:
            center = CGPointMake(left, bottom);
            break;
        case uAdPositionBottomRightOfScreen:
            center = CGPointMake(right, bottom);
            break;
        case uAdPositionCenterOfScreen:
            center = CGPointMake(centerX, centerY);
            break;
        default:
            break;
    }
    view.center = center;
}

@end
