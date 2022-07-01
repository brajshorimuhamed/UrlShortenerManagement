using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortenerWebApi.Models.DomainLayer.Entities
{
    public class ShortURLModel
    {
        public int Id { get; set; }
        public string ShortURL { get; set; }
        public string OriginalURL { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
