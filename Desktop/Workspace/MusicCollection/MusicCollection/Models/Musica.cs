using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Models
{
    public class Musica
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "Debe ingresar un nombre de artista")]
        public string Artista { get; set; }
        [Display(Name ="Título")]

        [Required(ErrorMessage = "Debe especificar un título")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Debe especificar al menos tres caracteres")]
        public string Titulo { get; set; }
        [Range(1700, 2099, ErrorMessage = "Debe especificar un rango entre 1700 y 2099")]
        [Display(Name = "Año")]
        public int Ano { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Solo letras")]
        [Required]
        public string Formato { get; set; }
        public int GeneroId { get; set; }
        public virtual Genero? Genero { get; set; }
    }
}
