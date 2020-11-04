using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineBooksDesktopApp.Model
{
    public class Author
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("nationality")]
        public string? Nationality { get; set; }

        [JsonPropertyName("dataOfBirth")]
        public DateTime? DataOfBirth { get; set; }

        [JsonPropertyName("placeOfBirth")]
        public string? PlaceOfBirth { get; set; }

        [JsonPropertyName("countryOfBirth")]
        public string? CountryOfBirth { get; set; }

        [JsonPropertyName("dateOfDeath")]
        public DateTime? DateOfDeath { get; set; }

        [JsonPropertyName("placeOfDeath")]
        public string? PlaceOfDeath { get; set; }

        [JsonPropertyName("countryOfDeath")]
        public string? CountryOfDeath { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("image")]
        public byte[]? Image { get; set; }

        [JsonPropertyName("isAlive")]
        public bool? IsAlive { get; set; }
    }
}
