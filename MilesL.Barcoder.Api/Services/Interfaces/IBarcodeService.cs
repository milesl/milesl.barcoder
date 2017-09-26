using MilesL.Barcoder.Api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesL.Barcoder.Api.Services.Interfaces
{
    /// <summary>
    /// Interface representing the barcode service
    /// </summary>
    public interface IBarcodeService
    {
        /// <summary>
        /// Method for retrieving a list of all barcodes
        /// </summary>
        /// <returns>A collection of barcodes</returns>
        IEnumerable<IBarcode> GetBarcodes();

        /// <summary>
        /// Method for adding new barcodes
        /// </summary>
        /// <param name="barcode">A implementation of <see cref="IBarcode"/> interface</param>
        /// <returns>A implementation of <see cref="IBarcode"/> interface</returns>
        IBarcode AddBarcode(IBarcode barcode);
    }
}
