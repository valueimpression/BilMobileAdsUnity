//
//  UBilMobileAds.swift
//  Unity-iPhone
//
//  Created by HNL_MAC on 11/12/20.
//

import Foundation
import BilMobileAds

@objc public class UnityPlugin : NSObject {
    
    @objc public static let shared = UnityPlugin()
    
    private override init() {}
    
    // MARK: - PBMobileAds
    @objc public func UPBMobileAdsInitialize(testMode: Bool) {
        PBMobileAds.shared.initialize(testMode: false)
    }
    @objc public func UPBMobileAdsEnableCOPPA() {
        PBMobileAds.shared.log(logType: .info, "UPBMobileAdsEnableCOPPA")
        PBMobileAds.shared.enableCOPPA()
    }
    @objc public func UPBMobileAdsDisableCOPPA() {
        PBMobileAds.shared.log(logType: .info, "UPBMobileAdsDisableCOPPA")
        PBMobileAds.shared.disableCOPPA()
    }
    @objc public func UPBMobileAdsSetGender(gender: Int) {
        PBMobileAds.shared.log(logType: .info, "UPBMobileAdsSetGender: \(gender)")
        
        if gender == 0 {
            PBMobileAds.shared.setGender(gender: .unknown)
        } else if gender == 1 {
            PBMobileAds.shared.setGender(gender: .male)
        } else if gender == 2 {
            PBMobileAds.shared.setGender(gender: .female)
        }
    }
    @objc public func UPBMobileAdsSetYearOfBirth(yob: Int) {
        PBMobileAds.shared.log(logType: .info, "UPBMobileAdsSetYearOfBirth: \(yob)")
        PBMobileAds.shared.setYearOfBirth(yob: yob)
    }
    
}
