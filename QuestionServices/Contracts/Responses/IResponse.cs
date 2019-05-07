using System;
using System.Collections.Generic;
using System.Text;

namespace RandomQuestionInterview.QuestionServices.Contracts
{
    public interface IResponse
    {
        string Message { get; set; }

        bool ErrorOccured { get; set; }

        string ErrorMessage { get; set; }
    }
}
