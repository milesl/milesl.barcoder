using System;
using MilesL.Barcoder.Api.Models.Interfaces;

namespace MilesL.Barcoder.Api.Models
{
    /// <summary>
    /// Model representing a Barcode
    /// </summary>
    public class Barcode : IBarcode
    {
        /// <summary>
        /// Gets or sets the Id for the barcode
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the message for the barcode
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the format for the barcode
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the date scanned for the barcode
        /// </summary>
        public DateTime? DateScanned { get; set; }
    }
}
