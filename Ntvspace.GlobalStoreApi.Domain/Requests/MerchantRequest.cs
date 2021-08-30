namespace Ntvspace.GlobalStoreApi.Domain.Requests
{
    /// <summary>
    /// Represents a create merchant request object
    /// </summary>
    public class MerchantRequest
    {
        /// <summary>
        /// Gets or sets the merchant name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// Gets or sets the merchant description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the merchant logo.
        /// </summary>
        public string Logo { get; set; }
        /// <summary>
        /// Gets or sets the merchant classification.
        /// </summary>
        public int MerchantClassificationId { get; set; }
    }
}
