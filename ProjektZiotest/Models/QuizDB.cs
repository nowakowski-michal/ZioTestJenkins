using Microsoft.EntityFrameworkCore;

namespace ProjektZiotest.Models
{
    public class QuizDB : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder
     optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SQL5113.site4now.net;Initial Catalog=db_aa77f9_zio2024ipp;User ID=db_aa77f9_zio2024ipp_admin;Password=ipp2024!;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestQuestion>()
                .HasKey(tq => new { tq.TestId, tq.QuestionId});

            modelBuilder.Entity<TestQuestion>()
                .HasOne(tq => tq.Test)
                .WithMany(t => t.TestQuestions)
                .HasForeignKey(tq => tq.TestId);

            modelBuilder.Entity<TestQuestion>()
                .HasOne(tq => tq.Question)
                .WithMany(q => q.TestQuestions)
                .HasForeignKey(tq => tq.QuestionId);
        }
    }
}
