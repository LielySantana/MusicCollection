using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicCollection.Models
{
    public class GeneroViewModel
    {
        public List<Genero>? Generos { get; set; }
        public SelectList? ListaGeneros { get; set; }
        public string? FiltroGenero { get; set; }
        public string? Busqueda { get; set; }
    }
}
