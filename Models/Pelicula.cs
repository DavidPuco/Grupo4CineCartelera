using System.ComponentModel.DataAnnotations;

namespace Grupo4CineCartelera.Models
{
    public class Pelicula
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El director es obligatorio.")]
        public string Director { get; set; } = string.Empty;

        [Required(ErrorMessage = "La duración es obligatoria.")]
        public int DuracionMinutos { get; set; }
    }
}