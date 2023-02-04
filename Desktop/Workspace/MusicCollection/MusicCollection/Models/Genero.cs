using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [Display(Name ="Descripción")]        
        public string? Descripcion { get; set; }

        [Display(Name = "Fecha Creación")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }
        public string? Icono { get; set; } 
    }
}