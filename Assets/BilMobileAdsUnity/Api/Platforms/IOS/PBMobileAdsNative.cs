using System;
using System.Runtime.InteropServices;
using BilMobileAdsUnity.Common;
using GoogleMobileAds.IOS;
using UnityEngine;

namespace BilMobileAdsUnity.IOS
{
    public class PBMobileAdsNative : IPBMobileAds
    {
        private static PBMobileAdsNative instance = new PBMobileAdsNative();
        public static PBMobileAdsNative Instance
        {
            get
            {
                return instance;
            }
        }
        private IntPtr pbmAdsUnity;

        private PBMobileAdsNative()
        {
            this.pbmAdsUnity = (IntPtr)GCHandle.Alloc(this);
        }

        #region PBMobileAds Methor Implement
        public void Initialize(bool testMode)
        {
            Externs.UPBMobileAdsInitialize(testMode);
        }
        public void EnableCOPPA()
        {
            Externs.UPBMobileAdsEnableCOPPA();
        }
        public void DisableCOPPA()
        {
            Externs.UPBMobileAdsDisableCOPPA();
        }
        public void SetGender(int gender)
        {
            Externs.UPBMobileAdsSetGender(gender);
        }
        public void SetYearOfBirth(int yearOfBirth)
        {
            Externs.UPBMobileAdsSetYearOfBirth(yearOfBirth);
        }
        public void SetAppPauseOnBackground(bool pause)
        {
            Externs.USetAppPauseOnBackground(pause);
        }
        #endregion

        public void Dispose()
        {
            ((GCHandle)this.pbmAdsUnity).Free();
        }
        ~PBMobileAdsNative()
        {
            this.Dispose();
        }
    }
}