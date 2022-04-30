using Announcement.Application.DTO;
using Announcement.Domain.Entities;
using AutoMapper;

namespace Announcement.Application.Common.Mapping
{
    public class AnnounceProfile : Profile
    {
        public AnnounceProfile()
        {
            CreateMap<AnnounceDto, Announce>().ReverseMap();
            CreateMap<Announce, AnnounceResponse>().ReverseMap();
        }
    }
}
