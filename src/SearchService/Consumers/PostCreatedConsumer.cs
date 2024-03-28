using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService;

public class PostCreatedConsumer : IConsumer<PostCreated>
{
    private readonly IMapper _mapper;

    public PostCreatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task Consume(ConsumeContext<PostCreated> context)
    {
        Console.WriteLine("----> Consuming post created: " + context.Message.Id);

        var post = _mapper.Map<Post>(context.Message);

        if(post.Title == "Foo") throw new ArgumentException("Can not pos this shit men!");

        await post.SaveAsync();
    }
}
