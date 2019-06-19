using Microsoft.EntityFrameworkCore;

namespace EfCoreTruncateStringsBasedOnMaxLength
{
    public partial class TutorialContext : DbContext
    {
        public TutorialContext()
        { }

        public TutorialContext(DbContextOptions<TutorialContext> options)
            : base(options)
        {
        }
        public virtual DbSet<NonImportantLog> NonImportantLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("CONNECTIONSTRING");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NonImportantLog>(entity =>
            {
                entity.ToTable("tblZipCode");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.LongMessage1).HasMaxLength(20);
                entity.Property(e => e.LongMessage2).HasMaxLength(20);
            });
        }
    }
}