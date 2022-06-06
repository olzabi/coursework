using Microsoft.EntityFrameworkCore;

namespace Zabiiaka_v1.Models
{
    public class TermPaperContext : DbContext
    {
        public TermPaperContext(DbContextOptions<TermPaperContext> options) : base(options)
        {
        }

        public DbSet<TermPaper> TermPapers { get; set; }
    }
}
