using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RandomQuestionInterview.QuestionDAL.Contracts;
using RandomQuestionInterview.QuestionDAL.Context;
using RandomQuestionInterview.QuestionDAL.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace RandomQuestionInterview.QuestionDAL.Repositories
{
    class QuestionRepository : IQuestionRepository
    {
        readonly InterrogationContext _context;

        public QuestionRepository(InterrogationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async virtual Task<Question> Add(Question entity)
        {
            await _context.Questions.AddAsync(entity);
            return entity;
        }

        public async virtual Task<bool> Exist(int id)
        {
            return await _context.Questions.AnyAsync(c => c.QuestionId == id);
        }

        public async virtual Task<Question> Find(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async virtual Task<Question> Remove(int id)
        {
            var entity = await _context.Questions.FirstOrDefaultAsync(x => x.QuestionId == id);
            _context.Questions.Remove(entity);
            return entity;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual Question Update(Question entity)
        {
            _context.Questions.Update(entity);
            return entity;
        }

        public async virtual Task<IDbContextTransaction> StartTransaction()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public IQueryable<Question> GetAll()
        {
            return _context.Questions.AsQueryable<Question>();
        }
    }
}
