namespace Ae.Steam.Client.Entities
{
    public class SteamReviewsRequest
    {
        public SteamReviewsRequest(uint appId)
        {
            AppId = appId;
        }

        public SteamReviewFilter Filter { get; set; }
        public string Language { get; set; } = "all";
        public uint? DayRange { get; set; }
        public uint? StartOffset { get; set; }
        public SteamReviewType ReviewType { get; set; }
        public SteamReviewPurchaseType PurchaseType { get; set; }

        public uint AppId { get; set; }
    }
}
