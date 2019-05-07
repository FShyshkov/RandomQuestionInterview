using System;
using System.Collections.Generic;
using System.Text;
using RandomQuestionInterview.QuestionDAL.Entities;
using RandomQuestionInterview.QuestionServices.Contracts;
using RandomQuestionInterview.QuestionServices.DTO;

namespace RandomQuestionInterview.QuestionServices.Mappers
{
    internal class QuestionMapper : IQuestionMapper
    {
        public QuestionDTO Convert(Question question)
        {
            var tempQ = new QuestionDTO()
            {
                QuestionId = question.QuestionId,
                QuestionText = question.QuestionText
            };
            return tempQ;
        }

        public Question ConvertDTO(QuestionDTO question)
        {
            var tempQ = new Question()
            {
                QuestionId = question.QuestionId,
                QuestionText = question.QuestionText
            };
            return tempQ;
        }
    }
}
