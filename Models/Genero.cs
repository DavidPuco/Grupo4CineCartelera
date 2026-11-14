using System.ComponentModel.DataAnnotations; 

namespace Grupo4CineCartelera.Models
{
    public class Genero
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = "";

        public string? Descripcion { get; set; }

        public ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>();
    }
}