using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public sealed class SteamAppDetails
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("steam_appid")]
        public uint SteamAppId { get; set; }
        [JsonPropertyName("dlc")]
        public IReadOnlyList<uint> Dlc { get; set; } = new uint[0];
        [JsonPropertyName("packages")]
        public IReadOnlyList<uint> Packages { get; set; } = new uint[0];
        [JsonPropertyName("developers")]
        public IReadOnlyList<string> Developers { get; set; } = new string[0];
        [JsonPropertyName("publishers")]
        public IReadOnlyList<string> Publishers { get; set; } = new string[0];
        [JsonPropertyName("price_overview")]
        public SteamAppDetailsPriceOverview? PriceOverview { get; set; }
        [JsonPropertyName("is_free")]
        public bool IsFree { get; set; }
        [JsonPropertyName("required_age")]
        public string? RequiredAge { get; set; }
        [JsonPropertyName("categories")]
        public IReadOnlyList<SteamAppDetailsCategory> Categories { get; set; } = new SteamAppDetailsCategory[0];
        [JsonPropertyName("genres")]
        public IReadOnlyList<SteamAppDetailsGenre> Genres { get; set; } = new SteamAppDetailsGenre[0];
        public string? ControllerSupport { get; set; }
        [JsonPropertyName("detailed_description")]
        public string? DetailedDescription { get; set; }
        [JsonPropertyName("about_the_game")]
        public string? AboutTheGame { get; set; }
        [JsonPropertyName("short_description")]
        public string? ShortDescription { get; set; }
        [JsonPropertyName("supported_languages")]
        public string? SupportedLanguages { get; set; }

        [JsonPropertyName("pc_requirements")]
        internal JsonElement PcRequirementsInternal { get; set; }
        public SteamAppDetailsRequirements? PcRequirements => PcRequirementsInternal.ValueKind != JsonValueKind.Object ? null :
            JsonSerializer.Deserialize<SteamAppDetailsRequirements>(PcRequirementsInternal.GetRawText());

        [JsonPropertyName("mac_requirements")]
        internal JsonElement MacRequirementsInternal { get; set; }
        public SteamAppDetailsRequirements? MacRequirements => MacRequirementsInternal.ValueKind != JsonValueKind.Object ? null :
            JsonSerializer.Deserialize<SteamAppDetailsRequirements>(MacRequirementsInternal.GetRawText());

        [JsonPropertyName("linux_requirements")]
        internal JsonElement LinuxRequirementsInternal { get; set; }
        public SteamAppDetailsRequirements? LinuxRequirements => LinuxRequirementsInternal.ValueKind != JsonValueKind.Object ? null :
            JsonSerializer.Deserialize<SteamAppDetailsRequirements>(LinuxRequirementsInternal.GetRawText());

        [JsonPropertyName("platforms")]
        public SteamAppDetailsPlatforms Platforms { get; set; }

        [JsonPropertyName("screenshots")]
        public IReadOnlyList<SteamAppDetailsScreenshot> Screenshots { get; set; } = new SteamAppDetailsScreenshot[0];

        [JsonPropertyName("movies")]
        public IReadOnlyList<SteamAppDetailsMovie> Movies { get; set; } = new SteamAppDetailsMovie[0];

        [JsonPropertyName("legal_notice")]
        public string? LegalNotice { get; set; }
        [JsonPropertyName("ext_user_account_notice")]
        public string? ExternalUserAccountNotice { get; set; }
        [JsonPropertyName("header_image")]
        public Uri? HeaderImage { get; set; }
        [JsonPropertyName("website")]
        public Uri? Website { get; set; }
        [JsonPropertyName("background")]
        public Uri? Background { get; set; }

        [JsonPropertyName("release_date")]
        public SteamAppDetailsReleaseDate ReleaseDate { get; set; }

        [JsonPropertyName("recommendations")]
        public SteamAppDetailsRecommendations Recommendations { get; set; }

        [JsonPropertyName("support_info")]
        public SteamAppDetailsSupportInfo SupportInfo { get; set; }

        public override string ToString() => Name;
    }
}
