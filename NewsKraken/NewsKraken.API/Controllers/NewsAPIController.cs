using Core.NewsAPI;
using Core.NewsAPI.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace NewsKraken.API.Controllers;

[Controller, Route("controller")]
public class NewsAPIController : ControllerBase
{
    private readonly NewsGatherer _newsGatherer;
    // private readonly 
    public NewsAPIController(NewsGatherer newsGatherer)
    {
        _newsGatherer = newsGatherer;
    }

    [HttpGet("/news-api")]
    public async Task<IActionResult> GetNewsFiltered([FromBody] SearchNewsModel model)
    {
        var result = await _newsGatherer.GatherNews(model);

        return Ok(new NewsApiPayload()
        {
            Articles = result.Articles
        });
    }

    // [HttpPost("/news.api/save")]
    // public async Task<IActionResult> SaveArticle([FromBody] SaveArticleModel model)
    // {
    //     
    // }
}