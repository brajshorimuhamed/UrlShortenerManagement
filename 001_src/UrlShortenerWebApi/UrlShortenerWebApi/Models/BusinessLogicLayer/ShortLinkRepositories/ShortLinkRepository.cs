using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortenerWebApi.Models.DataAccessLayer;
using UrlShortenerWebApi.Models.DomainLayer.Entities;

namespace UrlShortenerWebApi.Models.BusinessLogicLayer.ShortLinkRepositories
{
    public class ShortLinkRepository : IShortLinkRepository
    {
        private readonly UrlShortenerDbContext _context;

        public ShortLinkRepository(UrlShortenerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<ShortURLModel> GetShortURLModelByLongURL(string longURL)
        {
            return await _context.ShortURLModel.Where(x => x.OriginalURL == longURL).FirstOrDefaultAsync();
        }

        public async Task<ShortURLModel> GetShortURLModelByShortURL(string shortURL)
        {
            var urlShort = await _context.ShortURLModel.FirstOrDefaultAsync(x => x.ShortURL == shortURL);

            return urlShort;
        }

        public async Task<IList<ShortURLModel>> GetShortURLModels()
        {
            return await _context.ShortURLModel.ToListAsync();
        }

        public async Task<ShortURLModel> SaveShortURLModel(ShortURLModel model)
        {
            try
            {
                ShortURLRequestModel requestModel = new ShortURLRequestModel();

                //var https_LongURL = "https://" + requestModel.LongURL + "";
                //var http_LongURL = "http://" + requestModel.LongURL + "";

                //var https_Url = "https://" + requestModel.Url + ".com";
                //var http_Url = "http://" + requestModel.Url + ".com";

                if (model.Url != null)
                {
                    model.Url = "" + model.Url + "/" + model.ShortURL + "";
                    _context.ShortURLModel.Add(model);
                    await _context.SaveChangesAsync();
                }

                //else if (model.Url != null)
                //{
                //    model.Url = "" + model.Url + "/" + model.ShortURL + "";
                //    _context.ShortURLModel.Add(model);
                //    await _context.SaveChangesAsync();
                //}

                //model.ShortURL = "" + requestModel.Url + "" + model.ShortURL + "";
                //model.ShortURL = "" + requestModel.Url + "" + model.ShortURL + "";
                //model.ShortURL = "/*https//gj.al/*/" + model.ShortURL + "";
                //_context.ShortURLModel.Add(model);
                //await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return model;
        }
    }
}
