using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using twitter_contest_dotnet.Data;
using twitter_contest_dotnet.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<twitter_contest_dotnetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("twitter_contest_dotnetContext")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITwitterService, TwitterService>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
        {
            builder.WithOrigins("http://localhost:8080")
                //.AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Paging-Headers");
        });
});

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
