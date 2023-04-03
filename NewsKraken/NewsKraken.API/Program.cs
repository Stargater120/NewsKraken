using Core.NewsAPI;
using Core.NewsAPI.RequestModels;
using NewsKraken.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var news = new NewsGatherer();
await news.GatherNews(new SearchNewsModel()
{
    Q = "finance"
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
