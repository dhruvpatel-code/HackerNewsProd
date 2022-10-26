using HackerNewsProd.Models;
using HackerNewsProd.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsProd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("MyCorsImplementationPolicy")]
    public class HackerController : Controller
    {
        private readonly IHackerArticles _hackerArticles;

        public HackerController(IHackerArticles hackerArticles)
        {
            _hackerArticles = hackerArticles;
        }

        // GET: api/<ArticlesController>
        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            List<HackerModel> newsArticleList = new List<HackerModel>();

            try
            {
                newsArticleList = await _hackerArticles.GetNewsArticles();

                if (newsArticleList.Count() == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return Ok(newsArticleList);
        }
    }
}
