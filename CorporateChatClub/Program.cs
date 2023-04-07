using SimpleInjector.Lifestyles;
using SimpleInjector;
using CorporateChatClub;
using CorporateChatClub.Service.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Simple Injector

var container = new Container();
container.Options.DefaultLifestyle = Lifestyle.Scoped;
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

builder.Services.AddSimpleInjector(container, options =>
{
    options.AddAspNetCore().AddControllerActivation();
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<UserMapperProfile>();
});

//DAPPER

container.RegisterPackages(new[] { typeof(RegisterServices).Assembly });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
