using Newtonsoft.Json;
using System;

namespace ProCampHome.Models.Responses
{
    /// <summary>
    /// Represents customers response model.
    /// </summary>
    [Serializable]
    public class CustomersResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [JsonProperty]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [JsonProperty]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        [JsonProperty]
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        [JsonProperty]
        public DateTime CreatedDate { get; set; }
    }
}
