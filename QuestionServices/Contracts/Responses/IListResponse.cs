using System.Collections.Generic;

namespace RandomQuestionInterview.QuestionServices.Contracts
{    
        public interface IListResponse<TModel> : IResponse
        {
            IEnumerable<TModel> Model { get; set; }
        }
}
