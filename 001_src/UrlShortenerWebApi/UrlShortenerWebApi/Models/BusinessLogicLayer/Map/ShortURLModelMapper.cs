using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortenerWebApi.Models.BusinessLogicLayer.Utilities;
using UrlShortenerWebApi.Models.DomainLayer.Entities;

namespace UrlShortenerWebApi.Models.BusinessLogicLayer.Map
{
    public static class ShortURLModelMapper
    {
        public static ShortURLModel MapRequestModelToDBModel(ShortURLRequestModel requestModel)
        {
            ShortURLModel result = new ShortURLModel
            {
                CreatedAt = DateTime.Now,
                OriginalURL = requestModel.LongURL,
                Url = requestModel.Url
            };

            result.ShortURL = TokenGenerator.GenerateShortUrl();

            return result;
        }
    }
}
