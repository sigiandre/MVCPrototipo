using MVCPrototipo.Models;
using Microsoft.EntityFrameworkCore;


namespace MVCPrototipo.Models
{
    public class ContextoCursos : DbContext
    {
        public ContextoCursos(DbContextOptions<ContextoCursos> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<CursoInstructor>().HasKey(ci => new {ci.CursoId, ci.InstructorId});
        }
        public DbSet<Instructor> Instructor { get; set; }

        public DbSet<Curso> Curso { get; set; }

        public DbSet<Precio> Precio { get; set; }

        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<CursoInstructor> CursoInstructor { get; set; }
    }
}