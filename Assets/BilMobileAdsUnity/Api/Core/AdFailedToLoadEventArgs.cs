using System;

namespace BilMobileAdsUnity.Api
{
    // Event that occurs when an ad fails to load.
    public class AdFailedToLoadEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
