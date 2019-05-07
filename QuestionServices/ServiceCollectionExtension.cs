using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RandomQuestionInterview.QuestionServices.Contracts;
using RandomQuestionInterview.QuestionServices.Services;

namespace RandomQuestionInterview.QuestionServices
{
    public static class ServiceCollectionExtension
    {
        public static void AddQuestionServices(this IServiceCollection services)
        {
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IQuestionMapper, Mappers.QuestionMapper>();
        }
    }
}
