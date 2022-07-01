using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortenerWebApi.Models.DomainLayer.Entities;

namespace UrlShortenerWebApi.Models.BusinessLogicLayer.ShortLinkRepositories
{
    public interface IShortLinkRepository
    {
        Task<IList<ShortURLModel>> GetShortURLModels();
        Task<ShortURLModel> GetShortURLModelByShortURL(string shortURL);
        Task<ShortURLModel> GetShortURLModelByLongURL(string longURL);

        Task<ShortURLModel> SaveShortURLModel(ShortURLModel model);
    }
}
