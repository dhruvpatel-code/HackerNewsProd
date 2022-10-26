using System.Collections.Generic;
using System.Threading.Tasks;
using HackerNewsProd.Models;


namespace HackerNewsProd.Services
{
    public interface IHackerArticles
    {
        Task<List<HackerModel>> GetNewNewsArticles();
    }
}
