using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortenerWebApi.Models.DomainLayer.Entities;

namespace UrlShortenerWebApi.Models.BusinessLogicLayer.ShortLinks
{
    public interface IShortLinkService
    {
        Task<IList<ShortURLModel>> GetShortURLModels();
        Task<ShortURLModel> GetShortURLModelByShortURL(string shortURL);

        Task<ShortURLModel> SaveShortURLModel(ShortURLRequestModel model);
    }
}
