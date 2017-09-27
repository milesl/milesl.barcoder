using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MilesL.Barcoder.Api.Services.Interfaces;
using AutoMapper;
using MilesL.Barcoder.Api.ViewModels;
using MilesL.Barcoder.Api.Models.Interfaces;

namespace MilesL.Barcoder.Api.Controllers
{
    /// <summary>
    /// The controller for the Barcode endpoint to manage barcodes
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BarcodeController : Controller
    {
        /// <summary>
        /// Instance of the barcode service
        /// </summary>
        private IBarcodeService barcodeService;

        /// <summary>
        /// Instance of the mapping provider
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// Initiated a instance of the <see cref="BarcodeController"/> class
        /// </summary>
        /// <param name="barcodeService">A implementation of the <see cref="IBarcodeService"/> interface</param>
        /// <param name="mapper">A implementation of the <see cref="IMapper"/> interface</param>
        public BarcodeController(IBarcodeService barcodeService, IMapper mapper)
        {
            this.barcodeService = barcodeService;
            this.mapper = mapper;
        }

        /// <summary>
        /// HTTP Get route providing access to a collection of barcodes
        /// </summary>
        /// <returns>A collection of barcodes</returns>
        [HttpGet]
        public async Task<IEnumerable<BarcodeViewModel>> Get()
        {
            try
            {
                var barcodes = await this.barcodeService.GetBarcodes();
                return this.mapper.Map<List<BarcodeViewModel>>(barcodes);
            }
            catch (Exception ex)
            {
                // log ex to app insights rather than throw
                throw ex;
            }
        }

        /// <summary>
        /// HTTP Post route providing the ability to add a new barcode
        /// </summary>
        /// <param name="barcode">A instance of a barcode</param>
        [HttpPost]
        public async Task<BarcodeViewModel> Post([FromBody]BarcodeViewModel barcode)
        {
            try
            {
                var barcodeToAdd = this.mapper.Map<IBarcode>(barcode);
                barcodeToAdd = await this.barcodeService.AddBarcode(barcodeToAdd);
                return this.mapper.Map<BarcodeViewModel>(barcodeToAdd);
            }
            catch (Exception ex)
            {
                // log ex to app insights rather than throw
                throw ex;
            }
        }
    }
}
