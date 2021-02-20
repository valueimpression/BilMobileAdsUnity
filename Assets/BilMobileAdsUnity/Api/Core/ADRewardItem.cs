using System;

namespace BilMobileAdsUnity.Api
{
    public class ADRewardItem : EventArgs
    {
        public string Type { get; set; }
        public double Amount { get; set; }
    }
}
