using AutoMapper;
using YaChitay.Models;
using YaChitay.Models.Book;

namespace YaChitay.Mapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookDTO, BookModel>().ForMember(x => x.Genres, opt => opt.Ignore());
        }
    }
}
