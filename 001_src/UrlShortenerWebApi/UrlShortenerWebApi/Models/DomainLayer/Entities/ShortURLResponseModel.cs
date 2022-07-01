using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortenerWebApi.Models.DomainLayer.Entities
{
    public class ShortURLResponseModel
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public ShortURLModel URLModel { get; set; }
    }
}
