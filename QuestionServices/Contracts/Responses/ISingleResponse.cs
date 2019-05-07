using System;
using System.Collections.Generic;
using System.Text;

namespace RandomQuestionInterview.QuestionServices.Contracts
{
    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }
}
