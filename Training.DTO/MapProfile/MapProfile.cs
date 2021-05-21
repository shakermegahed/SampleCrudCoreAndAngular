using AutoMapper;

using Training.Domain.Entities;
using Training.Domain.ViewModel.Pro;


namespace Training.DTO.MapProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateProductViewModel, Product>().ReverseMap();
            CreateMap<Product, UpdateProductViewModel>()
                 .ForMember(DTO => DTO.ProductId, e => e.MapFrom(x => x.Id)).ReverseMap();
            CreateMap<Product, ProductViewModel>()
           .ForMember(DTO => DTO.ProductId, e => e.MapFrom(x => x.Id))
           
           .ForMember(DTO => DTO.CategoryName, e => e.MapFrom(x => x.Categories.Name)).ReverseMap();

          


        }


    }

}
