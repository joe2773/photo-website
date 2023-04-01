
using AutoMapper;
using MyPhotoApp.Domain.Models;
using MyPhotoApp.Application.Dto;

namespace MyPhotoApp.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>(); // Domain to DTO
            CreateMap<UserDto, User>()
            .ForMember(photo => photo.Comments, opt => opt.Ignore())
            .ForMember(photo => photo.Likes, opt => opt.Ignore())
            .ForMember(photo => photo.Photos, opt => opt.Ignore()); // DTO to Domain
        }
    }
}
