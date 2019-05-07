using System;
using System.Collections.Generic;
using System.Text;
using RandomQuestionInterview.QuestionDAL.Entities;
using RandomQuestionInterview.QuestionServices.DTO;

namespace RandomQuestionInterview.QuestionServices.Contracts
{
    internal interface IQuestionMapper
    {
        QuestionDTO Convert(Question question);
        Question ConvertDTO(QuestionDTO question);
    }
}
