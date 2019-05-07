using Microsoft.EntityFrameworkCore;
using RandomQuestionInterview.QuestionDAL.Entities;
using RandomQuestionInterview.QuestionDAL.Context.Configurations;

namespace RandomQuestionInterview.QuestionDAL.Context
{
    public class InterrogationContext : DbContext
    {
        public InterrogationContext(DbContextOptions<InterrogationContext> options)
            : base(options)
        {
        }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());

            #region QuestionSeed
            modelBuilder.Entity<Question>().HasData(
                new Question { QuestionId = 1, QuestionText = "От какого класса наследуются все обекты C#?" },
                new Question { QuestionId = 2, QuestionText = "Расскажите в чем разница между value и reference типами." },
                new Question { QuestionId = 3, QuestionText = "Что такое делегаты и события" },
                new Question { QuestionId = 4, QuestionText = "Опишите разницу между абстрактными классами и интерфейсами" },
                new Question { QuestionId = 5, QuestionText = "В чем разница между Dispose и Finalize?" },
                new Question { QuestionId = 6, QuestionText = "Опишите работу Garbage Collector в C#." },
                new Question { QuestionId = 7, QuestionText = "Что такое версионность WebAPI." },
                new Question { QuestionId = 8, QuestionText = "Перечислите елементы SOLID" },
                new Question { QuestionId = 9, QuestionText = "Опишите что означает Restful API" },
                new Question { QuestionId = 10, QuestionText = "Что такое Dependency Injection?" });
            #endregion

        }
    }
}
