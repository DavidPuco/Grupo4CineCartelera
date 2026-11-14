
using System.ComponentModel.DataAnnotations;

namespace Grupo4CineCartelera.Models
{
    public class Pelicula
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(150, ErrorMessage = "El título no puede superar los 150 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El director es obligatorio.")]
        [StringLength(100, ErrorMessage = "El director no puede superar los 100 caracteres.")]
        public string Director { get; set; } = string.Empty;

        [Required(ErrorMessage = "La duración es obligatoria.")]
        public int DuracionMinutos { get; set; }
    }
}