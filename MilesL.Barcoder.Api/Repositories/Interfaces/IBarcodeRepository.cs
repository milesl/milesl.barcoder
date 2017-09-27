using System.Collections.Generic;
using System.Threading.Tasks;
using MilesL.Barcoder.Api.Models.Interfaces;

namespace MilesL.Barcoder.Api.Repositories.Interfaces
{
    /// <summary>
    /// Interface representing the barcode repository
    /// </summary>
    public interface IBarcodeRepository : IRepository<IBarcode>
    {
        /// <summary>
        /// Method for retrieving a list of all barcodes
        /// </summary>
        /// <returns>A collection of barcodes</returns>
        Task<IEnumerable<IBarcode>> GetBarcodes();

        /// <summary>
        /// Method for adding new barcodes
        /// </summary>
        /// <param name="barcode">A implementation of <see cref="IBarcode"/> interface</param>
        /// <returns>A implementation of <see cref="IBarcode"/> interface</returns>
        Task<IBarcode> AddBarcode(IBarcode barcode);
    }
}
