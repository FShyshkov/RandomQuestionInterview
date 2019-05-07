using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using RandomQuestionInterview.QuestionDAL.Entities;

namespace RandomQuestionInterview.QuestionDAL.Contracts
{
    public interface IQuestionRepository
    {
        Task<Question> Find(int id);
        Task<Question> Add(Question entity);
        Question Update(Question entity);
        Task<Question> Remove(int id);
        Task<bool> Exist(int id);
        Task<int> SaveAsync();
        Task<IDbContextTransaction> StartTransaction();
        IQueryable<Question> GetAll();
    }
}
