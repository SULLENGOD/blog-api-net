using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchService.Models;
using SearchService.RequestHelpers;

namespace SearchService.Controllers;

[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Post>>> SearchPost([FromQuery]SearchParams searchParams)
    {
        var query = DB.PagedSearch<Post, Post>();

        if(!string.IsNullOrEmpty(searchParams.SearchTerm))
        {
            query.Match(Search.Full, searchParams.SearchTerm);
        }

        query = searchParams.OrderBy switch
        {
            "desc" => query.Sort(x => x.Descending(a => a.CreatedAt)),
            "asc" => query.Sort(x => x.Ascending(a => a.CreatedAt)),
            _ => query.Sort(x => x.Ascending(a => a.CreatedAt))
        };
 
        if(!string.IsNullOrEmpty(searchParams.Author))
        {
            query.Match(x => x.Author == searchParams.Author);
        }

        if(!string.IsNullOrEmpty(searchParams.Title))
        {
            query.Match(x => x.Title == searchParams.Title);
        }

        query.PageNumber(searchParams.PageNumber);
        query.PageSize(searchParams.PageSize);

        var result = await query.ExecuteAsync();

        return Ok(new
        {
            results = result.Results,
            pageNumber = result.PageCount,
            totalCount = result.TotalCount
        });
    }
}
