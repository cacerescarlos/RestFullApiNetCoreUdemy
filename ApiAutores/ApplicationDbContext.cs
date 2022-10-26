using ApiAutores.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiAutores
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        /// <summary>
        /// Tablas que se van a generar
        /// </summary>
        public DbSet<Autor> Autores { get; set; }
    }
}
