using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesL.Barcoder.Api.ViewModels
{
    public class BarcodeViewModel
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
