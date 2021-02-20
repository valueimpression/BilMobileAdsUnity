
using UnityEngine;
using BilMobileAdsUnity.Common;

namespace BilMobileAdsUnity.Android
{
    public class PBMobileAdsNative : AndroidJavaProxy, IPBMobileAds
    {
        private static PBMobileAdsNative instance = new PBMobileAdsNative();
        public static PBMobileAdsNative Instance
        {
            get
            {
                return instance;
            }
        }

        private AndroidJavaObject pbmNative; // JAVA Class

        private PBMobileAdsNative() : base(Utils.UnityADListenerClassName)
        {
            AndroidJavaClass uPlayerClass = new AndroidJavaClass(Utils.UnityPlayerClassName);
            AndroidJavaObject activity = uPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.pbmNative = new AndroidJavaObject(Utils.PBMobileAdsClassName, activity);
        }

        public void Initialize(bool testMode)
        {
            this.pbmNative.Call("initialize", testMode);
        }

        public void EnableCOPPA()
        {
            this.pbmNative.Call("enableCOPPA");
        }

        public void DisableCOPPA()
        {
            this.pbmNative.Call("disableCOPPA");
        }

        public void SetGender(int gender)
        {
            this.pbmNative.Call("setGender", gender);
        }

        public void SetYearOfBirth(int yearOfBirth)
        {
            this.pbmNative.Call("setYearOfBirth", yearOfBirth);
        }

        public void SetAppPauseOnBackground(bool pause)
        {
            // Default Android is to pause when app is backgrounded.
        }
    }
}