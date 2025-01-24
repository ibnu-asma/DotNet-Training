using Microsoft.AspNetCore.WebUtilities;
using Understanding_the_Mvc.Iservices;
using Understanding_the_Mvc.Models;

namespace Understanding_the_Mvc.Services;

public class PostService : IPostService
{
    private static readonly List<Post> AllPosts = new();

    public Task CreatePost(Post item)
    {
        AllPosts.Add(item);
        return Task.CompletedTask;
    }

    public Task<Post?> UpdatePost(int id, Post item)
    {
        var post = AllPosts.FirstOrDefault( p => p.Id == id);
        if (post != null)
        {
            post.Title = item.Title;
            post.Body = item. Body;
            post.UserId = item.UserId;
        }
        return Task.FromResult(post);
    }

    public Task<Post?> GetPost(int id)
    {
        return Task.FromResult(AllPosts.FirstOrDefault(p => p.Id == id));
        
    }

    public Task<List<Post>> GetAllPosts()
    {
        return Task.FromResult(AllPosts.ToList());
    }

    public Task DeletePost(int id)
    {
        var post = AllPosts.FirstOrDefault(p => p.Id == id);
        if (post != null)
        {
            AllPosts.Remove(post);
        }

        return Task.CompletedTask;
    }

}
