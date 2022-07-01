using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortenerWebApi.Models.BusinessLogicLayer.Map;
using UrlShortenerWebApi.Models.BusinessLogicLayer.ShortLinkRepositories;
using UrlShortenerWebApi.Models.DomainLayer.Entities;

namespace UrlShortenerWebApi.Models.BusinessLogicLayer.ShortLinks
{
    public class ShortLinkService : IShortLinkService
    {
        private readonly IShortLinkRepository _shortLinkRepository;

        public ShortLinkService(IShortLinkRepository shortLinkRepository)
        {
            _shortLinkRepository = shortLinkRepository;
        }

        public async Task<ShortURLModel> GetShortURLModelByShortURL(string shortURL)
        {
            return await _shortLinkRepository.GetShortURLModelByShortURL(shortURL);
        }

        public async Task<IList<ShortURLModel>> GetShortURLModels()
        {
            return await _shortLinkRepository.GetShortURLModels();
        }

        public async Task<ShortURLModel> SaveShortURLModel(ShortURLRequestModel model)
        {
            ShortURLModel previouslySaved = await _shortLinkRepository.GetShortURLModelByLongURL(model.LongURL);
            if (previouslySaved != null)
            {
                new ShortURLResponseModel { URLModel = previouslySaved, Success = true, Message = "This url has been saved previously" };
            }
            else
            {
                ShortURLModel saveModel = await _shortLinkRepository.SaveShortURLModel(ShortURLModelMapper.MapRequestModelToDBModel(model));

                new ShortURLResponseModel
                {
                    URLModel = saveModel,
                    Success = true,
                    Message = "Saved Successfully"
                };
            }

            return previouslySaved;
        }
    }
}
