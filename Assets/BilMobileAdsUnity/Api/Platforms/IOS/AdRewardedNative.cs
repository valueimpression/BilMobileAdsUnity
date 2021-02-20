using System;
using System.Runtime.InteropServices;
using AOT;
using BilMobileAdsUnity.Api;
using BilMobileAdsUnity.Common;
using GoogleMobileAds.IOS;

namespace BilMobileAdsUnity.IOS
{
    public class AdRewardedNative : IAdRewarded
    {
        private IntPtr rewardedUnity; // Unity Class
        private IntPtr rewardedNative; // ObjC Class
        private IntPtr RewardedNative
        {
            get
            {
                return this.rewardedNative;
            }
            set
            {
                this.rewardedNative = value;
            }
        }

        #region Rewarded Events
        public event EventHandler<EventArgs> OnAdLoaded;
        public event EventHandler<EventArgs> OnAdOpened;
        public event EventHandler<EventArgs> OnAdClosed;
        public event EventHandler<ADRewardItem> OnUserEarnedReward;
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToShow;
        #endregion

        #region Rewarded Callback Types
        internal delegate void UADRewardedOnAdLoaded(IntPtr rewardedUnity);
        internal delegate void UADRewardedOnAdOpened(IntPtr rewardedUnity);
        internal delegate void UADRewardedOnAdClosed(IntPtr rewardedUnity);
        internal delegate void UADRewardedOnUserEarnedReward(IntPtr rewardedUnity, string rewardType, double rewardAmount);
        internal delegate void UADRewardedOnAdFailedToLoad(IntPtr rewardedUnity, string error);
        internal delegate void UADRewardedOnAdFailedToPresent(IntPtr rewardedUnity, string error);
        #endregion

        #region Rewarded Methor Implement
        public void CreateRewarded(string adUnitId)
        {
            this.rewardedUnity = (IntPtr)GCHandle.Alloc(this);
            this.RewardedNative = Externs.UADRewardedCreate(this.rewardedUnity, adUnitId);
            Externs.UADRewardedSetCallbacks(
                        this.RewardedNative,
                        RewardedOnAdLoaded,
                        RewardedOnAdOpened,
                        RewardedOnAdClosed,
                        RewardedOnUserEarnedReward,
                        RewardedOnAdFailedToLoad,
                        RewardedOnAdFailedToPresent
                    );
        }
        public void PreLoadRewarded()
        {
            Externs.UADRewardedPreload(this.RewardedNative);
        }
        public void ShowRewarded()
        {
            Externs.UADRewardedShow(this.RewardedNative);
        }
        public void DestroyRewarded()
        {
            Externs.UADRewardedDestroy(this.RewardedNative);
            this.RewardedNative = IntPtr.Zero;
        }
        public bool IsReadyRewarded()
        {
            return Externs.UADRewardedIsReady(this.RewardedNative);
        }
        public void Dispose()
        {
            this.DestroyRewarded();
            ((GCHandle)this.rewardedUnity).Free();
        }
        ~AdRewardedNative()
        {
            this.Dispose();
        }
        #endregion

        #region Rewarded Callback Methods
        private static AdRewardedNative IntPtrToAdNative(IntPtr rewardedUnity)
        {
            GCHandle handle = (GCHandle)rewardedUnity;
            return handle.Target as AdRewardedNative;
        }
#if UNITY_IOS
        [MonoPInvokeCallback(typeof(UADRewardedOnAdLoaded))]
#endif
        private static void RewardedOnAdLoaded(IntPtr rewardedUnity)
        {
            AdRewardedNative client = IntPtrToAdNative(rewardedUnity);
            if (client.OnAdLoaded != null)
            {
                client.OnAdLoaded(client, EventArgs.Empty);
            }
        }
#if UNITY_IOS
        [MonoPInvokeCallback(typeof(UADRewardedOnAdOpened))]
#endif
        private static void RewardedOnAdOpened(IntPtr rewardedUnity)
        {
            AdRewardedNative client = IntPtrToAdNative(rewardedUnity);
            if (client.OnAdOpened != null)
            {
                client.OnAdOpened(client, EventArgs.Empty);
            }
        }
#if UNITY_IOS
        [MonoPInvokeCallback(typeof(UADRewardedOnAdClosed))]
#endif
        private static void RewardedOnAdClosed(IntPtr rewardedUnity)
        {
            AdRewardedNative client = IntPtrToAdNative(rewardedUnity);
            if (client.OnAdClosed != null)
            {
                client.OnAdClosed(client, EventArgs.Empty);
            }
        }
#if UNITY_IOS
        [MonoPInvokeCallback(typeof(UADRewardedOnUserEarnedReward))]
#endif
        private static void RewardedOnUserEarnedReward(IntPtr rewardedUnity, string rewardType, double rewardAmount)
        {
            AdRewardedNative client = IntPtrToAdNative(rewardedUnity);
            if (client.OnUserEarnedReward != null)
            {
                ADRewardItem args = new ADRewardItem()
                {
                    Type = rewardType,
                    Amount = rewardAmount
                };
                client.OnUserEarnedReward(client, args);
            }
        }
#if UNITY_IOS
        [MonoPInvokeCallback(typeof(UADRewardedOnAdFailedToLoad))]
#endif
        private static void RewardedOnAdFailedToLoad(IntPtr rewardedUnity, string error)
        {
            AdRewardedNative client = IntPtrToAdNative(rewardedUnity);
            if (client.OnAdFailedToLoad != null)
            {
                AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs()
                {
                    Message = error
                };
                client.OnAdFailedToLoad(client, args);
            }
        }
#if UNITY_IOS
        [MonoPInvokeCallback(typeof(UADRewardedOnAdFailedToPresent))]
#endif
        private static void RewardedOnAdFailedToPresent(IntPtr rewardedUnity, string error)
        {
            AdRewardedNative client = IntPtrToAdNative(rewardedUnity);
            if (client.OnAdFailedToShow != null)
            {
                AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs()
                {
                    Message = error
                };
                client.OnAdFailedToShow(client, args);
            }
        }
        #endregion
    }
}