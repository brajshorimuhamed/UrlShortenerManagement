using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortenerWebApi.Models.BusinessLogicLayer.ShortLinks;
using UrlShortenerWebApi.Models.DomainLayer.Entities;

namespace UrlShortenerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortUrlController : ControllerBase
    {
        private readonly IShortLinkService _shortLinkService;

        public ShortUrlController(IShortLinkService shortLinkService)
        {
            _shortLinkService = shortLinkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShortUrl()
        {
            var shortLinks = await _shortLinkService.GetShortURLModels();

            return Ok(shortLinks);
        }

        [HttpGet("{shorturl}")]
        public async Task<IActionResult> GetShortLink(string shorturl, [FromQuery(Name = "redirect")] bool redirect = true)
        {
            ShortURLModel model = await _shortLinkService.GetShortURLModelByShortURL(shorturl);

            if (model == null)
            {
                if (redirect)
                {
                    return Redirect(model.OriginalURL);
                }
                else
                {
                    return Ok(model);
                }
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> PostShortLink([FromBody] ShortURLRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _shortLinkService.SaveShortURLModel(model);
                if (result == null)
                {
                    return Ok(result);
                }

                return BadRequest(ModelState.Values);
            }

            return NoContent();
        }
    }
}
