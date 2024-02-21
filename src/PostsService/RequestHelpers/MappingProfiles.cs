using AutoMapper;
using PostsService.DTOs;
using PostsService.Entities;

namespace PostsService.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Post, PostDto>();
        CreateMap<CreatePostDto, Post>();
    }
}
