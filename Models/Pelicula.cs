using System.ComponentModel.DataAnnotations;

namespace Grupo4CineCartelera.Models
{
    public class Pelicula
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(150, ErrorMessage = "El título no puede superar los 150 caracteres.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El director es obligatorio.")]
        [StringLength(100, ErrorMessage = "El director no puede superar los 100 caracteres.")]
        [Display(Name = "Director")]
        public string Director { get; set; } = string.Empty;

        [Required(ErrorMessage = "La duración es obligatoria.")]
        [Range(1, 600, ErrorMessage = "La duración debe estar entre 1 y 600 minutos.")]
        [Display(Name = "Duración en minutos")]
        public int DuracionMinutos { get; set; }

        [Display(Name = "Género")]
        public int GeneroId { get; set; }
        public Genero? Genero { get; set; }
    }
}