using System;

namespace ProCampHome.Models
{
    /// <summary>
    /// Represents item entity model.
    /// </summary>
    public class ItemEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the available quantity.
        /// </summary>
        /// <value>
        /// The available quantity.
        /// </value>
        public int AvailableQuantity { get; set; }
    }
}
