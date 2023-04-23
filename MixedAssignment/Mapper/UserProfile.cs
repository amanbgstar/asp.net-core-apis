using AutoMapper;
using MixedAssignment.Domain.Models;
using MixedAssignment.ViewModel.ProductVM;
using MixedAssignment.ViewModel.UserVM;

namespace MixedAssignment.Mapper
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterVM, User>().ReverseMap();
            CreateMap<UserRegiShowVM, User>().ReverseMap();

            CreateMap<ProductsVM, Product>().ReverseMap();
            CreateMap<ProductsGetVM, Product>().ReverseMap();
        }
    }
}
