using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortenerWebApi.Models.DomainLayer.Entities;

namespace UrlShortenerWebApi.Models.DataAccessLayer
{
    public class UrlShortenerDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public UrlShortenerDbContext(DbContextOptions<UrlShortenerDbContext> options) : base(options)
        {

        }

        public DbSet<ShortURLModel> ShortURLModel { get; set; }
    }
}
