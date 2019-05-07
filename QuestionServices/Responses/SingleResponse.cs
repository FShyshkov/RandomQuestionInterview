using RandomQuestionInterview.QuestionServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomQuestionInterview.QuestionServices.Responses
{
    public class SingleResponse<TModel> : ISingleResponse<TModel> where TModel : new()
    {
        public SingleResponse()
        {
            Model = new TModel();
        }

        public string Message { get; set; }

        public bool ErrorOccured { get; set; }

        public string ErrorMessage { get; set; }

        public TModel Model { get; set; }
    }
}
