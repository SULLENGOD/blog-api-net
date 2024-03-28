using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService;

public class PostDeletedConsumer : IConsumer<PostDeleted>
{
    public async Task Consume(ConsumeContext<PostDeleted> context)
    {
        Console.WriteLine("----> Consuming post deleted: " + context.Message.Id);

        var result = await DB.DeleteAsync<Post>(context.Message.Id);

        if(!result.IsAcknowledged)
            throw new MessageException(typeof(PostDeleted), "Something wrong");
    }
}
