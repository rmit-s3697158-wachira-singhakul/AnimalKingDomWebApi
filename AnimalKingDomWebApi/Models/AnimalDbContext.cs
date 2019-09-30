using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalKingDomWebApi.Models
{
    public class AnimalDbContext :DbContext
    {
        public AnimalDbContext()
        {

        }
        public AnimalDbContext(DbContextOptions<AnimalDbContext> options)
            : base(options)
        {
        }
        public DbSet<AnimalDetails> AnimalDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=ios-animal-kingdom.database.windows.net;database=ios_animalkingdom;user=master;password=Animal2019");
            }
        }
    }
}
