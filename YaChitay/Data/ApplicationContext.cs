using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YaChitay.Entities.Models;

namespace YaChitay.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<BookModel> Book { get; set; } = default!;
        public DbSet<AuthorModel> Author { get; set; } = default!;
        public DbSet<GenreModel>? Genre { get; set; }


    }
}
