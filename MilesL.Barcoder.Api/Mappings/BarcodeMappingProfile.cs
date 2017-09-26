using AutoMapper;
using MilesL.Barcoder.Api.Models.Interfaces;
using MilesL.Barcoder.Api.ViewModels;

namespace MilesL.Barcoder.Api.Mappings
{
    public class BarcodeMappingProfile : Profile
    {
        public BarcodeMappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<IBarcode, BarcodeViewModel>();
            CreateMap<BarcodeViewModel, IBarcode>();
        }
    }
}
