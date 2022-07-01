using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static UrlShortenerWebApi.Models.Validations.CustomValidation;

namespace UrlShortenerWebApi.Models.DomainLayer.Entities
{
    public class ShortURLRequestModel
    {
        [Required]
        [CheckUrlValid(ErrorMessage = "Please enter a valid url")]
        public string LongURL { get; set; }

        public string Url { get; set; }

        public DateTime TimeStamp
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
