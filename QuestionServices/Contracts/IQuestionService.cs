using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RandomQuestionInterview.QuestionServices.DTO;

namespace RandomQuestionInterview.QuestionServices.Contracts
{
    public interface IQuestionService
    {
        Task<ISingleResponse<QuestionDTO>> GetRandomQuestionAsync();
        Task<ISingleResponse<QuestionDTO>> GetQuestionByIdAsync(int id);
        Task<IPagedResponse<QuestionDTO>> GetAllQuestionsAsync(int pageSize = 5, int pageNumber = 1);
        Task<ISingleResponse<QuestionDTO>> CreateQuestionAsync(string questionText);
        Task<IResponse> DeleteQuestionByIdAsync(int id);
        Task<ISingleResponse<QuestionDTO>> UpdateQuestionAsync(int id, string questionText);
    }
}
