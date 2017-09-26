using MilesL.Barcoder.Api.Repositories.Interfaces;
using System.Data;
using System.Collections;
using System.Linq;
using Dapper;
using System.Collections.Generic;
using MilesL.Barcoder.Api.Models.Interfaces;
using MilesL.Barcoder.Api.Models;

namespace MilesL.Barcoder.Api.Repositories
{
    /// <summary>
    /// Repository for managing Barcodes
    /// </summary>
    public class BarcodeRepository : IBarcodeRepository
    {
        /// <summary>
        /// Instance of the database connection
        /// </summary>
        private IDbConnection connection;

        /// <summary>
        /// Initiates a instance of the <see cref="BarcodeRepository"/> class
        /// </summary>
        /// <param name="connection">Instance of the database connection</param>
        public BarcodeRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Method for retrieving a list of all barcodes
        /// </summary>
        /// <returns>A collection of barcodes</returns>
        public IEnumerable<IBarcode> GetBarcodes()
        {
            return this.connection.Query<Barcode>(StoredProcedures.GetBarcodes,commandType: CommandType.StoredProcedure).ToList();
        }

        /// <summary>
        /// Method for adding new barcodes
        /// </summary>
        /// <param name="barcode">A implementation of <see cref="IBarcode"/> interface</param>
        /// <returns>A implementation of <see cref="IBarcode"/> interface</returns>
        public IBarcode AddBarcode(IBarcode barcode)
        {
            return this.connection.Query<Barcode>(StoredProcedures.AddBarcodes, new { message = barcode.Message, format = barcode.Format}, commandType: CommandType.StoredProcedure).Single();
        }

        /// <summary>
        /// Stored produres used by the class
        /// </summary>
        public class StoredProcedures
        {
            /// <summary>
            /// Stored procedure for getting barcodes
            /// </summary>
            public const string GetBarcodes = "usp_get_barcodes";

            /// <summary>
            /// Stored procedure for adding a barcode
            /// </summary>
            public const string AddBarcodes = "usp_add_barcode";
        }
    }
}
