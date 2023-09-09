using Microsoft.EntityFrameworkCore;

namespace StudentCrudUsingEF.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        //fetch the date from DB and store at application side
        //Dbset will translate LINQ quries in SQL and fire in DB
        public DbSet<Student> Stud { get; set; }
    }
}
