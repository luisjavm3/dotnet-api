using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Certification> Certifications { get; set; }

    }
}
