using AutoMapper;
using BookLibraryCleanArchitecture.Domain.BookAggregate.Entities;
using BookLibraryCleanArchitecture.Domain.BookAggregate;
using BookLibraryCleanArchitecture.Domain.UserAggregate;
using BookLibraryCleanArchitecture.Application.Entities.DataTransferObjects;

namespace BookLibraryCleanArchitecture.Server.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorDto, Author>().
            ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id)
            )
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.Name}")
            )
            .ForMember(
                dest => dest.Country,
                opt => opt.MapFrom(src => $"{src.Country}")
            )
            .ForMember
            (
                dest => dest.Books,
                opt => opt.Ignore()
            )
            .ReverseMap();

            CreateMap<BookDto, Book>()
            //.ForMember(
            //    dest => dest.Id,
            //    opt => opt.MapFrom(src => Guid.NewGuid())
            //)
            .ForMember(
                dest => dest.ISBN,
                opt => opt.MapFrom(src => src.ISBN)
            )
            .ForMember(
                dest => dest.Publisher,
                opt => opt.MapFrom(src => src.Publisher)
            )
            .ForMember(
                dest => dest.NumberOfPages,
                opt => opt.MapFrom(src => src.NumberOfPages)
            )
            .ForMember(
                dest => dest.NumberOfCopies,
                opt => opt.MapFrom(src => src.NumberOfCopies)
            )
            .ForMember(
                dest => dest.LoanedQuantity,
                opt => opt.MapFrom(src => src.LoanedQuantity)
            )
            .ForMember(
                dest => dest.Genre,
                opt => opt.MapFrom(src => src.Genre)
            )
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => src.Status)
            )
            .ForMember(
                dest => dest.ReleaseYear,
                opt => opt.MapFrom(src => src.ReleaseYear)
            )
            .ForMember(
                dest => dest.Title,
                opt => opt.MapFrom(src => src.Title)
            )
            .ForMember(
                dest => dest.Version,
                opt => opt.MapFrom(src => src.Version)
            )
            .ForMember(dest => dest.Authors, opt => opt.Ignore())
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id)
            ).ReverseMap();

            CreateMap<UserDto, ApplicationUser>().
            ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id)
            )
            .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => $"{src.Name}")
            )
            .ForMember(
                dest => dest.Address,
                opt => opt.MapFrom(src => $"{src.Address}")
            )
            .ForMember
            (
                dest => dest.Status,
                opt => opt.MapFrom(src => $"{src.Status}")
            )
            .ForMember
            (
                dest => dest.BirthDate,
                opt => opt.MapFrom(src => $"{src.BirthDate}")
            )
            .ForMember
            (
                dest => dest.Email,
                opt => opt.MapFrom(src => $"{src.Email}")
            )
            .ForMember
            (
                dest => dest.UserName,
                opt => opt.MapFrom(src => $"{src.UserName}")
            )
            .ForMember
            (
                dest => dest.PhoneNumber,
                opt => opt.MapFrom(src => $"{src.PhoneNumber}")
            )
            .ForMember
            (
                dest => dest.PhoneNumberConfirmed,
                opt => opt.MapFrom(src => $"{src.PhoneNumberConfirmed}")
            )
            .ForMember
            (
                dest => dest.EmailConfirmed,
                opt => opt.MapFrom(src => $"{src.EmailConfirmed}")
            )
            .ReverseMap();

            CreateMap<UserForRegistrationDto, ApplicationUser>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
