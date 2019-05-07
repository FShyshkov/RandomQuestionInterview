using RandomQuestionInterview.QuestionServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomQuestionInterview.QuestionServices.Responses
{
    public class Response : IResponse
    {
        public string Message { get; set; }
        public bool ErrorOccured { get; set; }
        public string ErrorMessage { get; set; }      
    }
}
