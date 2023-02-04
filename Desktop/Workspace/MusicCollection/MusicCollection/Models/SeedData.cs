using Microsoft.EntityFrameworkCore;
using MusicCollection.Data;

namespace MusicCollection.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MusicCollectionContext(
                serviceProvider.GetRequiredService<DbContextOptions<MusicCollectionContext>>()))
            {
                if (!context.Musica.Any())
                {
                    context.Musica.AddRange(
                        new Musica
                        {
                            Artista = "Bad Bunny",
                            Titulo = "Un disco",
                            Ano = 2022,
                            Formato = "CD",
                            GeneroId = 7
                        },
                        new Musica
                        {
                            Artista = "Omega",
                            Titulo = "El Fuelte: preso de nuevo",
                            Ano = 2020,
                            Formato = "MP3",
                            GeneroId = 7
                        }
                     );
                    context.SaveChanges();

                }
                // buscar si existen generos
                if (context.Generos.Any())
                {
                    // si existen no hace nada
                    return;
                }

                context.Generos.AddRange(
                    new Genero
                    {
                        Nombre = "Merengue",
                        Descripcion = "Musica dominicana",
                        FechaCreacion = DateTime.Now
                    },
                    new Genero
                    {
                        Nombre = "Rock",
                        Descripcion = "Musica Americana",
                        FechaCreacion = DateTime.Parse("1950-05-01")
                    },
                    new Genero
                    {
                        Nombre = "Dembow",
                        Descripcion = "Musica urbana - FREE ROCHY",
                        FechaCreacion = DateTime.Now
                    },
                    new Genero
                    {
                        Nombre = "Techno",
                        Descripcion = "Electronico",
                        FechaCreacion = DateTime.Now
                    }
                );

                context.SaveChanges();
            }
        }
    }
}