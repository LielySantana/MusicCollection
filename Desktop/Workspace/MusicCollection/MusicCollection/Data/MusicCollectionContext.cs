using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicCollection.Models;

namespace MusicCollection.Data
{
    public class MusicCollectionContext : DbContext
    {
        public MusicCollectionContext (DbContextOptions<MusicCollectionContext> options)
            : base(options)
        {
        }

        public DbSet<MusicCollection.Models.Genero>? Generos { get; set; }
        public DbSet<MusicCollection.Models.Musica>? Musica { get; set; }
    }
}
