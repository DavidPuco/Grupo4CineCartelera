using Microsoft.EntityFrameworkCore;
using Grupo4CineCartelera.Models;

namespace Grupo4CineCartelera.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Genero> Generos { get; set; }
    }
}