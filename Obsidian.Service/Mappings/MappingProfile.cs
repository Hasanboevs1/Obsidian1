using AutoMapper;
using Obsidian.Domain.Entities;
using Obsidian.Service.DTOs.Comments;
using Obsidian.Service.DTOs.Posts;
using Obsidian.Service.DTOs.Users;

namespace Obsidian.Service.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Users
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForCreationDto>().ReverseMap();
        CreateMap<User, UserForUpdateDto>().ReverseMap();

        // Posts

        CreateMap<Post, PostForResultDto>().ReverseMap();
        CreateMap<Post, PostForCreationDto>().ReverseMap();
        CreateMap<Post, PostForUpdateDto>().ReverseMap();


        // Comments

        CreateMap<Comment, CommentForResultDto>().ReverseMap();
        CreateMap<Comment, CommentForCreationDto>().ReverseMap();
        CreateMap<Comment, CommentForUpdateDto>().ReverseMap();
    }
}
