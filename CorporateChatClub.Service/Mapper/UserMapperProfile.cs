using AutoMapper;
using CorporateChatClub.Application.DTO.User.ViewModels;
using CorporateChatClub.Application.DTO.User;
using CorporateChatClub.Domain.ViewModels.User;

namespace CorporateChatClub.Service.Mapper
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile() 
        {
            CreateMap<UserInformationDTO, UserInformation>().ReverseMap();
            CreateMap<UserPersonalDetailsDTO, UserPersonalDetails>().ReverseMap();
            CreateMap<UserContactDetailsDTO, UserContactDetails>().ReverseMap();
        }
    }
}
