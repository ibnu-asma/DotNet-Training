using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Understanding_the_Mvc.Iservices;
using Understanding_the_Mvc.Models;
using Understanding_the_Mvc.Services;

namespace Understanding_the_Mvc.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IPostService _service;

    public PostsController(IPostService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<ActionResult<List<Post>>> GetPosts()
    {
        var posts =  await _service.GetAllPosts();
        return Ok(posts);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await _service.GetPost(id);
        if( post != null)
        {
            return Ok(post);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post item)
    {
        await _service.CreatePost(item);
        return CreatedAtAction(nameof(GetPost), new {id = item.Id}, item);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Post>> UpdatePost(int id, Post item)
    {
        if( id != item.Id)
        {
            return BadRequest();
        }
        var post =   await _service.UpdatePost(id, item);
        if (post != null)
        {
            return Ok(item);
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(int id)
    {
        await _service.DeletePost(id);
        return NoContent();
    }
}
    
