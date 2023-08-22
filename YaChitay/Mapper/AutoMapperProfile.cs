using AutoMapper;
using YaChitay.Entities.Dto;
using YaChitay.Entities.DTO;
using YaChitay.Entities.Models;

namespace YaChitay.Mapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookRequestDto, Book>()
                .ForMember(x => x.Genres, opt => opt.Ignore())
                .ForMember(x => x.Authors, opt => opt.Ignore());

            CreateMap<Book, BookResponseDto>()
                .ForMember(dest => dest.AverageScore, opt => opt.MapFrom(src => src.ScoreVotes != 0 ? src.Score / src.ScoreVotes : 0))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.Select(x => $"{x.Name} {x.Patronymic} {x.Surname}").ToList()))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(x => x.Name).ToList()));

            CreateMap<AuthorRequestDto, Author>();

            CreateMap<Author, AuthorResponseDto>()
                .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => $"{src.Name} {src.Surname} {src.Patronymic}"))
                .ForMember(dest => dest.Initials, opt => opt.MapFrom(src => $"{src.Name[0]}. {src.Surname[0]}. {src.Patronymic}"))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToShortDateString().ToString()))
                .ForMember(dest => dest.DateOfDeath, opt => opt.MapFrom(src => src.DateOfDeath.Value.ToShortDateString().ToString()))
                .ForMember(dest => dest.LivedYears, opt => opt.MapFrom(src => (src.IsDead) ? (src.DateOfDeath.Value.Year - src.DateOfBirth.Year): (DateTime.Now.Year - src.DateOfBirth.Year)))
                .ForMember(dest => dest.AverageScore, opt => opt.MapFrom(src => src.ScoreVotes != 0 ? src.Score / src.ScoreVotes : 0));
        }
    }
}
