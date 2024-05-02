using Obsidian.Data.IRepositories;
using Obsidian.Data.Repositories;
using Obsidian.Service.IServices;
using Obsidian.Service.Services;

namespace Obsidian.Api.Extensions;

public static class ServiceExtentions
{
    public static void AddCustomService(this IServiceCollection services)
    {
        // service
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IPostService, PostService>();
        // Repos
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUserRepository, UserRespository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
    }
}
