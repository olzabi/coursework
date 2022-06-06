using coursework.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace coursework.DAL
{
    public class TermContext : DbContext
    {
        public TermContext() : base("TermContext")
        {
            //Database.SetInitializer<TermContext>(new CreateDatabaseIfNotExists<TermContext>());
            //Database.SetInitializer<TermContext>(null);

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<TermPaper> TermPapers { get; set; }
        public DbSet<Advisor> Advisors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            
        }

    }
}