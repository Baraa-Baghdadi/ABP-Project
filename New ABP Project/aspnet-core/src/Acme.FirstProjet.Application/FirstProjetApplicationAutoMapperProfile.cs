using Acme.Basket.Baskets;
using Acme.FirstProjet.Carts;
using Acme.FirstProjet.Patients;
using Acme.FirstProjet.Providers;
using Acme.FirstProjet.Providers.Mobile;
using Acme.FirstProjet.Providers.valueObject;

using AutoMapper;

namespace Acme.FirstProjet;

public class FirstProjetApplicationAutoMapperProfile : Profile
{
    public FirstProjetApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Cart, CartDto>();
        CreateMap<CartDto, Cart>();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Item, ItemDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : ""))
            .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.Product != null ? src.Product.Description : ""))
            .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product != null ? src.Product.Price : 0));
        CreateMap<ItemDto, Item>();




        CreateMap<WorkingTime, WorkingTimeDto>().ReverseMap();
        CreateMap<Provider, ProviderDto>()
            .ForMember(dest => dest.WorkingTimes, opt => opt.MapFrom(src => src.WorkingTimes != null ? src.WorkingTimes : null));
        CreateMap<ProviderAddress, ProviderAddressDto>().ReverseMap();
        CreateMap<PatientProvider, PatientProviderDto>()
            .ForMember(dest => dest.MobileNumber, opt => opt.MapFrom(src => src.Patient != null ? src.Patient.MobileNumber : ""))
            .ForMember(dest => dest.CountryCode, opt => opt.MapFrom(src => src.Patient != null ? src.Patient.CountryCode : ""));


        CreateMap<WorkingTime, WorkingTimeForMobileDto>();
        CreateMap<PatientProvider, PharmacyInfoDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Provider.Id != null ? src.Provider.Id : new System.Guid()))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Provider.PharmacyName != null ? src.Provider.PharmacyName : null))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Provider.PharmacyPhone != null ? src.Provider.PharmacyPhone : null))
            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Provider.LocationInfo.Longitude != null ? src.Provider.LocationInfo.Longitude : 0))
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Provider.LocationInfo.Latitude != null ? src.Provider.LocationInfo.Latitude : 0))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Provider.LocationInfo.Address != null ? src.Provider.LocationInfo.Address : null))
            .ForMember(dest => dest.AddingDate, opt => opt.MapFrom(src => src.AddingDate != null ? src.AddingDate : System.DateTime.Now))
            .ForMember(dest => dest.WorkingTimes, opt => opt.MapFrom(src => src.Provider.WorkingTimes != null ? src.Provider.WorkingTimes : null));


        CreateMap<PatientAddress, PatientAddressDto>().ReverseMap();
    }
}
