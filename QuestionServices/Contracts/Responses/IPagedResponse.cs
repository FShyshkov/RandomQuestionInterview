using System;
using System.Collections.Generic;
using System.Text;

namespace RandomQuestionInterview.QuestionServices.Contracts
{
    public interface IPagedResponse<TModel> : IListResponse<TModel>
    {
        int ItemsCount { get; set; }

        double PageCount { get; }
    }
}
