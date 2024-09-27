using Microsoft.EntityFrameworkCore;
using SurveyApp.Context.Entities;

namespace SurveyApp.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }  
        public DbSet<Interview> Interviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<Survey>()
            .HasMany(s => s.Questions)
            .WithOne(q => q.Survey)
            .HasForeignKey(q => q.SurveyId);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId);

            modelBuilder.Entity<Survey>()
                .HasMany(s => s.Interviews)
                .WithOne(i => i.Survey)
                .HasForeignKey(i => i.SurveyId);

            modelBuilder.Entity<Interview>()
                .HasMany(i => i.Results)
                .WithOne(r => r.Interview)
                .HasForeignKey(r => r.InterviewId);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Results)
                .WithOne(r => r.Question)
                .HasForeignKey(r => r.QuestionId);

            modelBuilder.Entity<Result>()
                       .HasMany(r => r.Answers)
                       .WithMany(a => a.Results)
                       .UsingEntity<Dictionary<string, object>>(
                           "ResultAnswer",
                           j => j
                               .HasOne<Answer>()
                               .WithMany()
                               .HasForeignKey("AnswerId")
                               .HasConstraintName("FK_Result_Answer"),
                           j => j
                               .HasOne<Result>()
                               .WithMany()
                               .HasForeignKey("ResultId")
                               .HasConstraintName("FK_Answer_Result"),
                           j =>
                           {
                               j.HasKey("ResultId", "AnswerId");
                           });
        }
    }
}
