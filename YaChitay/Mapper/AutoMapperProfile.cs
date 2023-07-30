using AutoMapper;
using YaChitay.Entities.DTO;
using YaChitay.Entities.Models;
using YaChitay.Entities.Response;

namespace YaChitay.Mapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookDTO, Book>()
                .ForMember(x => x.Genres, opt => opt.Ignore())
                .ForMember(x => x.Authors, opt => opt.Ignore());

            CreateMap<AuthorDTO, Author>().ForMember(x => x.PhotoData, opt => opt.Ignore());

            CreateMap<Book, BookResponse>()
                .ForMember(dest => dest.AverangeScore, opt => opt.MapFrom(src => src.ScoreVotes != 0 ? src.Score / src.ScoreVotes : 0))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.Select(x => $"{x.Name} {x.Patronymic} {x.Surname}").ToList()))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(x => x.Name).ToList()));
        }
    }
}
