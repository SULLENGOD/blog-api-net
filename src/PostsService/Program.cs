using MassTransit;
using Microsoft.EntityFrameworkCore;
using PostsService;
using PostsService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<PostDbContext>(opt => {
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMassTransit(x => 
{
    x.AddEntityFrameworkOutbox<PostDbContext>(o => 
    {
        o.QueryDelay = TimeSpan.FromSeconds(10);
        
        o.UsePostgres();
        o.UseBusOutbox();
    });

    x.AddConsumersFromNamespaceContaining<PostCreatedFailConsumer>();

    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("post", false));

    x.UsingRabbitMq((context, config) => 
    {
        config.ConfigureEndpoints(context);
    });
});

var app = builder.Build();


app.UseAuthorization();

app.MapControllers();

try
{
    DbInitializer.InitDB(app);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

app.Run();
