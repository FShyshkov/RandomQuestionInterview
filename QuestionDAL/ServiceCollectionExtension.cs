using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RandomQuestionInterview.QuestionDAL.Context;
using RandomQuestionInterview.QuestionDAL.Contracts;
using RandomQuestionInterview.QuestionDAL.Repositories;

namespace RandomQuestionInterview.QuestionDAL
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDALServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<InterrogationContext>(
                options => options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly("RandomQuestionInterview.QuestionDAL")));
            services.AddTransient<IQuestionRepository, QuestionRepository>();
        }
    }
}
