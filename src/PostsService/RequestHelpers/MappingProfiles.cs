using AutoMapper;
using Contracts;
using PostsService.DTOs;
using PostsService.Entities;

namespace PostsService.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Post, PostDto>();
        CreateMap<CreatePostDto, Post>();
        CreateMap<PostDto, PostCreated>();
        CreateMap<Post, PostUpdated>();
        CreateMap<Post, PostDeleted>();
    }
}
