using System;
using System.Collections.Generic;
using System.Text;

namespace RandomQuestionInterview.QuestionServices.Responses
{
    public static class ResponseExtensions
    {
        public static void SetError(this RandomQuestionInterview.QuestionServices.Contracts.IResponse response, string actionName, Exception ex)
        {

            response.ErrorOccured = true;

            if (ex is RandomQuestionInterview.QuestionServices.Exceptions.QuestionException cast)
            {
                response.ErrorMessage = ex.Message;
            }
            else  {
               response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }
        }
    }
}
