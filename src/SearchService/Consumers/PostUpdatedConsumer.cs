using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService;

public class PostUpdatedConsumer : IConsumer<PostUpdated>
{
    private readonly IMapper _mapper;
    public PostUpdatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task Consume(ConsumeContext<PostUpdated> context)
    {
        Console.WriteLine("----> Consuming post updated: " + context.Message.Id);

        var post = _mapper.Map<Post>(context.Message);

        var result = await DB.Update<Post>()
            .Match(a => a.ID == context.Message.Id)
            .ModifyOnly(x => new
            {
                x.Title,
                x.Content,
                x.CoAuthors,
                x.Tags,
                x.Categories
            }, post)
            .ExecuteAsync();
        
        if (!result.IsAcknowledged)
            throw new MessageException(typeof(PostUpdated), "Something wrong");
    }
}
