using System;

namespace MilesL.Barcoder.Api.Models.Interfaces
{
    /// <summary>
    /// Interface representing a Barcode
    /// </summary>
    public interface IBarcode
    {
        /// <summary>
        /// Gets or sets the Id for the barcode
        /// </summary>
        int? Id { get; set; }

        /// <summary>
        /// Gets or sets the message for the barcode
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets the format for the barcode
        /// </summary>
        string Format { get; set; }

        /// <summary>
        /// Gets or sets the date scanned for the barcode
        /// </summary>
        DateTime? DateScanned { get; set; }
    }
}
