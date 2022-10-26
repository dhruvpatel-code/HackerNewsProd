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

        // Initialize ctor 
        public HackerController(IHackerArticles hackerArticles)
        {
            _hackerArticles = hackerArticles;
        }

        // This is the main Get controller. This async get method gets the new articles from HackerServices.
        [HttpGet]
        public async Task<IActionResult> GetNewArticles()
        {
            // Holds items from the API in a list to be held from the HackerModel
            List<HackerModel> newNewsArticleList = new List<HackerModel>();

            try
            {
                newNewsArticleList = await _hackerArticles.GetNewNewsArticles();

                if (newNewsArticleList.Count() == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            // Gets list of new news articles
            return Ok(newNewsArticleList);
        }
    }
}
