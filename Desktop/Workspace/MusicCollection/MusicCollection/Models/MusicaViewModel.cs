using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicCollection.Models
{
    public class MusicaViewModel
    {
        public List<Musica>? Musica { get; set; }
        public SelectList? ListaGeneros { get; set; }
        public int? FiltroGenero { get; set; }
        public string? Busqueda { get; set; }

    }
}
