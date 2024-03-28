using AutoMapper;
using Contracts;
using SearchService.Models;

namespace SearchService;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PostCreated, Post>();
        CreateMap<PostUpdated, Post>();
        CreateMap<PostDeleted, Post>();
    }
}
