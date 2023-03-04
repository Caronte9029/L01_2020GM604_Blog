using Microsoft.EntityFrameworkCore;

namespace L01_2020GM604_Blog.Modelos
{
    public class comentarios : DbContext
    {

        public comentarios(DbContextOptions<comentarios> options) : base (options) {
        
        

        }
        public DbSet<comentarios> comentario { get; set; }
    }
}
