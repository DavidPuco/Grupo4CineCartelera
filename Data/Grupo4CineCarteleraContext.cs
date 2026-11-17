using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class Grupo4CineCarteleraContext(DbContextOptions<Grupo4CineCarteleraContext> options) : IdentityDbContext<Grupo4CineCartelera.Models.ApplicationUser>(options)
{
}
