using AutoMapper;
using YaChitay.Entities.DTO;
using YaChitay.Entities.Models;

namespace YaChitay.Mapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookDTO, BookModel>()
                .ForMember(x => x.Genres, opt => opt.Ignore())
                .ForMember(x => x.Author, opt => opt.Ignore());
            CreateMap<AuthorDTO, AuthorModel>().ForMember(x => x.PhotoData, opt => opt.Ignore());
        }
    }
}
