using System;

namespace RandomQuestionInterview.QuestionServices.Exceptions
{
    public class QuestionException : Exception
    {
        public QuestionException()
            : base()
        {
        }

        public QuestionException(string message)
            : base(message)
        {
        }
    }
}
