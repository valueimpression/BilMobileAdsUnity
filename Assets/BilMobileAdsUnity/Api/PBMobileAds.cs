using BilMobileAdsUnity.Common;

namespace BilMobileAdsUnity.Api
{
    public class PBMobileAds
    {
        private readonly IPBMobileAds pbmNative = GetPBMobileAdsInstance();

        private static INativeFactory adsFactory;

        private static PBMobileAds instance;
        public static PBMobileAds Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PBMobileAds();
                }
                return instance;
            }
        }

        public static void Initialize(bool testMode)
        {
            Instance.pbmNative.Initialize(testMode);
        }
        public static void EnableCOPPA()
        {
            Instance.pbmNative.EnableCOPPA();
        }
        public static void DisableCOPPA()
        {
            Instance.pbmNative.DisableCOPPA();
        }
        public static void SetYearOfBirth(int yearOfBirth)
        {
            Instance.pbmNative.SetYearOfBirth(yearOfBirth);
        }
        public static void SetGender(Gender gender)
        {
            Instance.pbmNative.SetGender((int)gender);
        }
        public static void SetAppPauseOnBackground(bool pause)
        {
            Instance.pbmNative.SetAppPauseOnBackground(pause);
        }

        internal static INativeFactory GetFactory()
        {
            if (adsFactory == null)
            {
                adsFactory = new BilMobileAdFactory();
            }
            return adsFactory;
        }

        private static IPBMobileAds GetPBMobileAdsInstance()
        {
            return GetFactory().PBMobileAdsInstanceNative();
        }
    }

}