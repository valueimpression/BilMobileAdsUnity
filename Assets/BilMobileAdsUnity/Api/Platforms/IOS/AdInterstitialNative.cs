using System;
using System.Runtime.InteropServices;
using AOT;
using BilMobileAdsUnity.Api;
using BilMobileAdsUnity.Common;
using GoogleMobileAds.IOS;
using UnityEngine;

namespace BilMobileAdsUnity.IOS
{
    public class AdInterstitialNative : IAdInterstitial
    {
        private IntPtr interstitialUnity; // Unity Class
        private IntPtr interstitialNative; // ObjC Class
        private IntPtr InterstitialNative
        {
            get
            {
                return this.interstitialNative;
            }
            set
            {
                this.interstitialNative = value;
            }
        }

        #region Interstitial Events
        public event EventHandler<EventArgs> OnAdLoaded;
        public event EventHandler<EventArgs> OnAdOpened;
        public event EventHandler<EventArgs> OnAdClosed;
        public event EventHandler<EventArgs> OnAdClicked;
        public event EventHandler<EventArgs> OnAdLeftApplication;
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;
        #endregion

        #region Interstitial Callback Types
        internal delegate void UADInterstitialOnAdLoaded(IntPtr interstitialUnity);
        internal delegate void UADInterstitialOnAdOpened(IntPtr interstitialUnity);
        internal delegate void UADInterstitialOnAdClosed(IntPtr interstitialUnity);
        internal delegate void UADInterstitialWillLeaveApplication(IntPtr interstitialUnity);
        internal delegate void UADInterstitialOnAdFailedToLoad(IntPtr interstitialUnity, string error);
        #endregion

        #region Interstitial Methor Implement
        public void CreateInterstitial(string adUnitId)
        {
            this.interstitialUnity = (IntPtr)GCHandle.Alloc(this);
            this.InterstitialNative = Externs.UADInterstitialCreate(this.interstitialUnity, adUnitId);
            Externs.UADInterstitialSetCallbacks(
                        this.InterstitialNative,
                        InterstitialOnAdLoaded,
                        InterstitialOnAdOpened,
                        InterstitialOnAdClosed,
                        InterstitialWillLeaveApplication,
                        InterstitialOnAdFailedToLoad
                    );
        }

        public void PreLoadInterstitial()
        {
            Externs.UADInterstitialPreload(this.InterstitialNative);
        }

        public void ShowInterstitial()
        {
            Externs.UADInterstitialShow(this.InterstitialNative);
        }

        public void DestroyInterstitial()
        {
            Externs.UADInterstitialDestroy(this.InterstitialNative);
            this.InterstitialNative = IntPtr.Zero;
        }

        public bool IsReadyInterstitial()
        {
            return Externs.UADInterstitialIsReady(this.InterstitialNative);
        }

        public void Dispose()
        {
            this.DestroyInterstitial();
            ((GCHandle)this.interstitialUnity).Free();
        }

        ~AdInterstitialNative()
        {
            this.Dispose();
        }
        #endregion

        #region Interstitial Callback Methods
        private static AdInterstitialNative IntPtrToAdNative(IntPtr interstitialUnity)
        {
            GCHandle handle = (GCHandle)interstitialUnity;
            return handle.Target as AdInterstitialNative;
        }
#if UNITY_IOS
        [MonoPInvokeCallback(typeof(UADInterstitialOnAdLoaded))]
#endif
        private static void InterstitialOnAdLoaded(IntPtr interstitialUnity)
        {
            AdInterstitialNative client = IntPtrToAdNative(interstitialUnity);
            if (client.OnAdLoaded != null)
            {
                client.OnAdLoaded(client, EventArgs.Empty);
            }
        }
#if UNITY_IOS
        [MonoPInvokeCallback(typeof(UADInterstitialOnAdOpened))]
#endif
        private static void InterstitialOnAdOpened(IntPtr interstitialUnity)
        {
            AdInterstitialNative client = IntPtrToAdNative(interstitialUnity);
            if (client.OnAdOpened != null)
            {
                client.OnAdOpened(client, EventArgs.Empty);
            }
        }
#if UNITY_IOS
        [MonoPInvokeCallback(typeof(UADInterstitialOnAdClosed))]
#endif
        private static void InterstitialOnAdClosed(IntPtr interstitialUnity)
        {
            AdInterstitialNative client = IntPtrToAdNative(interstitialUnity);
            if (client.OnAdClosed != null)
            {
                client.OnAdClosed(client, EventArgs.Empty);
            }
        }
#if UNITY_IOS
        [MonoPInvokeCallback(typeof(UADInterstitialWillLeaveApplication))]
#endif
        private static void InterstitialWillLeaveApplication(IntPtr interstitialUnity)
        {
            AdInterstitialNative client = IntPtrToAdNative(interstitialUnity);
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
        [MonoPInvokeCallback(typeof(UADInterstitialOnAdFailedToLoad))]
#endif
        private static void InterstitialOnAdFailedToLoad(IntPtr interstitialUnity, string error)
        {
            AdInterstitialNative client = IntPtrToAdNative(interstitialUnity);
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