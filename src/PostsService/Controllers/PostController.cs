using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostsService.Data;
using PostsService.DTOs;
using PostsService.Entities;

namespace PostsService.Controllers;

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    private readonly PostDbContext _context;
    private readonly IMapper _mapper;

    public PostController(PostDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<PostDto>>> GetAllPosts()
    {
        var posts = await _context.Posts
            .OrderBy(x => x.CreatedAt)
            .ToListAsync();

        return _mapper.Map<List<PostDto>>(posts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostDto>> GetPostById(Guid id)
    {
        var post = await _context.Posts
            .FirstOrDefaultAsync(x => x.Id == id);

        if(post == null) return NotFound();

        return _mapper.Map<PostDto>(post);
    }

    [HttpPost]
    public async Task<ActionResult<PostDto>> CreatePost(CreatePostDto postDto)
    {
        var post = _mapper.Map<Post>(postDto);

        _context.Posts.Add(post);
        
        //TODO: Make excerp.

        var result = await _context.SaveChangesAsync() > 0;
        if(!result) return BadRequest("Soemthing Wrong");

        return CreatedAtAction(nameof(GetPostById),
            new {post.Id}, _mapper.Map<PostDto>(post));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePost(Guid id, UpdatePostDto updatePostDto)
    {
        var post = await _context.Posts
            .FirstOrDefaultAsync(x => x.Id == id);


        if(post == null) return NotFound();

        post.Title = updatePostDto.Title ?? post.Title;
        post.Content = updatePostDto.Content ?? post.Content;
        post.CoAuthors = updatePostDto.CoAthors ?? post.CoAuthors;
        post.Tags = updatePostDto.Tags ?? post.Tags;
        post.Categories = updatePostDto.Categories ?? post.Categories;

        var result = await _context.SaveChangesAsync() > 0;

        if(result) return Ok();

        return BadRequest("Something wrong!");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(Guid id) 
    {
        var post = await _context.Posts.FindAsync(id);
        if(post == null) return NotFound();

        _context.Posts.Remove(post);

        var result = _context.SaveChanges() > 0;
        if(!result) return BadRequest("Somethin Wrong");

        return Ok();
    }
}
