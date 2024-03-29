﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts;
using MassTransit;
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
    private readonly IPublishEndpoint _publishEndpoint;

    public PostController(PostDbContext context, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _context = context;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet]
    public async Task<ActionResult<List<PostDto>>> GetAllPosts(string date)
    {
        var query = _context.Posts.OrderBy(x => x.CreatedAt).AsQueryable();
        if(!string.IsNullOrEmpty(date))
        {
            query = query.Where(x => x.UpdatedAt.CompareTo(DateTime.Parse(date).ToUniversalTime()) > 0);
        }

        return await query.ProjectTo<PostDto>(_mapper.ConfigurationProvider).ToListAsync();
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

        var newPost = _mapper.Map<PostDto>(post);

        await _publishEndpoint.Publish(_mapper.Map<PostCreated>(newPost));

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

        await _publishEndpoint.Publish(_mapper.Map<PostUpdated>(post));

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

        await _publishEndpoint.Publish<PostDeleted>(new { Id = post.Id.ToString() });

        var result = _context.SaveChanges() > 0;
        if(!result) return BadRequest("Somethin Wrong");

        return Ok();
    }
}
