using MilesL.Barcoder.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MilesL.Barcoder.Api.Models.Interfaces;
using MilesL.Barcoder.Api.Repositories.Interfaces;

namespace MilesL.Barcoder.Api.Services
{
    /// <summary>
    /// Service for managing Barcodes
    /// </summary>
    public class BarcodeService : IBarcodeService
    {
        /// <summary>
        /// Instance of the barcode repository
        /// </summary>
        private IBarcodeRepository barcodeRepository;

        /// <summary>
        /// Initiates a instance of the <see cref="BarcodeRepository"/> class
        /// </summary>
        /// <param name="barcodeRepository">Instance of the <see cref="IBarcodeRepository"/> interface</param>
        public BarcodeService(IBarcodeRepository barcodeRepository)
        {
            this.barcodeRepository = barcodeRepository;
        }

        /// <summary>
        /// Method for retrieving a list of all barcodes
        /// </summary>
        /// <returns>A collection of barcodes</returns>
        public async Task<IBarcode> AddBarcode(IBarcode barcode)
        {
            var result = await this.barcodeRepository.AddBarcode(barcode);
            return result;
        }

        /// <summary>
        /// Method for adding new barcodes
        /// </summary>
        /// <param name="barcode">A implementation of <see cref="IBarcode"/> interface</param>
        /// <returns>A implementation of <see cref="IBarcode"/> interface</returns>
        public async Task<IEnumerable<IBarcode>> GetBarcodes()
        {
            var result = await this.barcodeRepository.GetBarcodes();
            return result;
        }
    }
}
