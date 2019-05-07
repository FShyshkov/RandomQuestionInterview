using Microsoft.EntityFrameworkCore;
using RandomQuestionInterview.QuestionDAL.Contracts;
using RandomQuestionInterview.QuestionDAL.Entities;
using RandomQuestionInterview.QuestionDAL.Extensions;
using RandomQuestionInterview.QuestionServices.Contracts;
using RandomQuestionInterview.QuestionServices.DTO;
using RandomQuestionInterview.QuestionServices.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomQuestionInterview.QuestionServices.Services
{
    class QuestionService : IQuestionService
    {
        readonly IQuestionRepository _repository;
        readonly IQuestionMapper _mapper;

        public QuestionService(IQuestionRepository repository, IQuestionMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ISingleResponse<QuestionDTO>> CreateQuestionAsync(string questionText)
        {
            var response = new SingleResponse<QuestionDTO>();
            var tempQuestion = new QuestionDTO() {
                QuestionText = questionText
            };

            using (var transaction = await _repository.StartTransaction())
            {
                try
                {
                    var tempq = await _repository.Add(_mapper.ConvertDTO(tempQuestion));
                    await _repository.SaveAsync();
                    response.Model = _mapper.Convert(tempq);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    response.SetError(nameof(CreateQuestionAsync), ex);
                }
            }
            return response;
        }

        public async Task<IResponse> DeleteQuestionByIdAsync(int id)
        {
            var response = new Response();

            try
            {
                // Retrieve question by id
                var entity = _repository.Find(id);

                if (entity == null)
                    return response;


                // Delete question
                var question = await _repository.Remove(id);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                response.SetError(nameof(DeleteQuestionByIdAsync), ex);
            }

            return response;
        }

        public async Task<IPagedResponse<QuestionDTO>> GetAllQuestionsAsync(int pageSize = 5, int pageNumber = 1)
        {
            var response = new PagedResponse<QuestionDTO>();

            try
            {
                // Get query
                IQueryable<Question> query = _repository.GetAll();

                // Set information for paging
                response.PageSize = pageSize;
                response.PageNumber = pageNumber;
                response.ItemsCount = await query.CountAsync();

                // Retrieve items, set model for response
                var questionList = await query.Paging(pageSize, pageNumber).ToListAsync();
                var questionListDTO = new List<QuestionDTO>();
                foreach (var quest in questionList)
                {
                    questionListDTO.Add(_mapper.Convert(quest));
                }

                response.Model = questionListDTO;
            }
            catch (Exception ex)
            {
                response.SetError(nameof(GetAllQuestionsAsync), ex);
            }

            return response;
        }

        public async Task<ISingleResponse<QuestionDTO>> GetQuestionByIdAsync(int id)
        {
            var response = new SingleResponse<QuestionDTO>();

            try
            {
                var question = await _repository.Find(id);
                var questionDTO = _mapper.Convert(question);

                response.Model = questionDTO;
            }
            catch (Exception ex)
            {
                response.SetError(nameof(GetQuestionByIdAsync), ex);
            }

            return response;
        }

        public async Task<ISingleResponse<QuestionDTO>> GetRandomQuestionAsync()
        {
            var response = new SingleResponse<QuestionDTO>();

            try
            {
                IQueryable<Question> query = _repository.GetAll();
                var itemsCount = await query.CountAsync();
                Random rnd = new Random();
                int randomQuestionId = rnd.Next(1, itemsCount);
                var questionList = await query.ToListAsync();
                response.Model = _mapper.Convert(questionList[randomQuestionId - 1]);
            }
            catch (Exception ex)
            {
                response.SetError(nameof(GetQuestionByIdAsync), ex);
            }

            return response;
        }

        public async Task<ISingleResponse<QuestionDTO>> UpdateQuestionAsync(int id, string questionText)
        {
            var response = new SingleResponse<QuestionDTO>();
            QuestionDTO questionDTO = new QuestionDTO
            {
                QuestionId = id,
                QuestionText = questionText
            };
            Question question = _mapper.ConvertDTO(questionDTO);
            using (var transaction = await _repository.StartTransaction())
            {
                try
                {
                    _repository.Update(question);
                    await _repository.SaveAsync();
                    response.Model = _mapper.Convert(question);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    response.SetError(nameof(UpdateQuestionAsync), ex);
                }
            }
            return response;
        }
    }
}
