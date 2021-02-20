using System;
using System.Runtime.InteropServices;
using AOT;
using BilMobileAdsUnity.Api;
using BilMobileAdsUnity.Common;
using GoogleMobileAds.IOS;

namespace BilMobileAdsUnity.IOS
{
    public class AdBannerNative : IAdBanner
    {
        private IntPtr bannerUnity; // Unity Class
        private IntPtr bannerNative; // ObjC Class
        private IntPtr BannerNative
        {
            get
            {
                return this.bannerNative;
            }
            set
            {
                this.bannerNative = value;
            }
        }

        #region Banner Events
        public event EventHandler<EventArgs> OnAdLoaded;
        public event EventHandler<EventArgs> OnAdOpened;
        public event EventHandler<EventArgs> OnAdClosed;
        public event EventHandler<EventArgs> OnAdClicked;
        public event EventHandler<EventArgs> OnAdLeftApplication;
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;
        #endregion

        #region Banner Callback Types
        internal delegate void UADBannerOnAdLoaded(IntPtr bannerUnity);
        internal delegate void UADBannerOnAdOpened(IntPtr bannerUnity);
        internal delegate void UADBannerOnAdClosed(IntPtr bannerUnity);
        internal delegate void UADBannerWillLeaveApplication(IntPtr bannerUnity);
        internal delegate void UADBannerOnAdFailedToLoad(IntPtr bannerUnity, string error);
        #endregion

        #region Banner Methor Implement
        public void CreateBanner(string adUnitId, AdPosition position)
        {
            this.bannerUnity = (IntPtr)GCHandle.Alloc(this);
            this.BannerNative = Externs.UADBannerCreate(this.bannerUnity, adUnitId, (int)position);
            Externs.UADBannerSetCallbacks(
                        this.BannerNative,
                        BannerOnAdLoaded,
                        BannerOnAdOpened,
                        BannerOnAdClosed,
                        BannerWillLeaveApplication,
                        BannerOnAdFailedToLoad
                    );
        }
        public void LoadBanner()
        {
            Externs.UADBannerLoad(this.BannerNative);
        }
        public void ShowBanner()
        {
            Externs.UADBannerShow(this.BannerNative);
        }
        public void HideBanner()
        {
            Externs.UADBannerHide(this.BannerNative);
        }
        public void DestroyBanner()
        {
            Externs.UADBannerDestroy(this.BannerNative);
            this.BannerNative = IntPtr.Zero;
        }
        public int GetWidthInPixelsBanner()
        {
            return Externs.UADBannerGetWidthInPixels(this.BannerNative);
        }
        public int GetHeightInPixelsBanner()
        {
            return Externs.UADBannerGetHeightInPixels(this.BannerNative);
        }
        public void SetPositionBanner(AdPosition adPosition)
        {
            Externs.UADBannerSetPosition(this.BannerNative, (int)adPosition);
        }
        
        public void Dispose()
        {
            this.DestroyBanner();
            ((GCHandle)this.bannerUnity).Free();
        }
        ~AdBannerNative()
        {
            this.Dispose();
        }
        #endregion

        #region Banner Callback Methods
        private static AdBannerNative IntPtrToAdNative(IntPtr bannerUnity)
        {
            GCHandle handle = (GCHandle)bannerUnity;
            return handle.Target as AdBannerNative;
        }
#if UNITY_IOS
        [MonoPInvokeCallback(typeof(UADBannerOnAdLoaded))]
#endif
        private static void BannerOnAdLoaded(IntPtr bannerUnity)
        {
            AdBannerNative client = IntPtrToAdNative(bannerUnity);
            if (client.OnAdLoaded != null)
            {
                client.OnAdLoaded(client, EventArgs.Empty);
            }
        }
#if UNITY_IOS
        [MonoPInvokeCallback(typeof(UADBannerOnAdOpened))]
#endif
        private static void BannerOnAdOpened(IntPtr bannerUnity)
        {
            AdBannerNative client = IntPtrToAdNative(bannerUnity);
            if (client.OnAdOpened != null)
            {
                client.OnAdOpened(client, EventArgs.Empty);
            }
        }
#if UNITY_IOS
        [MonoPInvokeCallback(typeof(UADBannerOnAdClosed))]
#endif
        private static void BannerOnAdClosed(IntPtr bannerUnity)
        {
            AdBannerNative client = IntPtrToAdNative(bannerUnity);
            if (client.OnAdClosed != null)
            {
                client.OnAdClosed(client, EventArgs.Empty);
            }
        }
#if UNITY_IOS
        [MonoPInvokeCallback(typeof(UADBannerWillLeaveApplication))]
#endif
        private static void BannerWillLeaveApplication(IntPtr bannerUnity)
        {
            AdBannerNative client = IntPtrToAdNative(bannerUnity);
            if (client.OnAdLeftApplication != null)
            {
                client.OnAdLeftApplication(client, EventArgs.Empty);
            }
            if (client.OnAdClicked != null)
            {
                client.OnAdClicked(client, EventArgs.Empty);
            }
        }
#if UNITY_IOS
        [MonoPInvokeCallback(typeof(UADBannerOnAdFailedToLoad))]
#endif
        private static void BannerOnAdFailedToLoad(IntPtr bannerUnity, string error)
        {
            AdBannerNative client = IntPtrToAdNative(bannerUnity);
            if (client.OnAdFailedToLoad != null)
            {
                AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs()
                {
                    Message = error
                };
                client.OnAdFailedToLoad(client, args);
            }
        }
        #endregion
    }
}