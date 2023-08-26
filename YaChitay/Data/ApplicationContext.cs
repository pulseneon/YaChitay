using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YaChitay.Entities.DTO;
using YaChitay.Entities.Models;

namespace YaChitay.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Author> Author { get; set; } = default!;
        public DbSet<Genre>? Genre { get; set; }

        public DbSet<BookImage> BookImage { get; set; } = default!;
        public DbSet<AuthorImage> AuthorImage { get; set; } = default!;

        public ApplicationContext (DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Author>().HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
