using Microsoft.EntityFrameworkCore;

namespace L01_2020GM604_Blog.Modelos
{
    public class calificaciones : DbContext
    {
        public calificaciones(DbContextOptions<calificaciones> options) : base(options)
        {


        }
        public DbSet<calificaciones> calificacion {get; set;}
    }
}
