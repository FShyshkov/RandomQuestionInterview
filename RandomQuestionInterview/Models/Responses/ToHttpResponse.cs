using System.Net;
using RandomQuestionInterview.QuestionServices.Contracts;
using RandomQuestionInterview.QuestionServices.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RandomQuestionInterview.Models.Responses
{
    public static class Extensions
    {
        public static IActionResult ToHttpResponse<TModel>(this IListResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.ErrorOccured)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NoContent;
            var settings = new JsonSerializerSettings
            {
                Culture = new System.Globalization.CultureInfo("ru-Ru")
            };
            var result = new JsonResult(response)
            {
                StatusCode = (int)status,
                SerializerSettings = settings
            };
            return result;
        }

        public static IActionResult ToHttpResponse<TModel>(this ISingleResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;
            
            if (response.ErrorOccured)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NotFound;

            var settings = new JsonSerializerSettings
            {
                Culture = new System.Globalization.CultureInfo("ru-Ru")
            };
            var result = new JsonResult(response)
            {
                StatusCode = (int)status,
                SerializerSettings = settings
            };
            return result;
        }

        public static IActionResult ToHttpResponse(this IResponse response)
        {
            var status = response.ErrorOccured ? HttpStatusCode.InternalServerError : HttpStatusCode.OK;
            var settings = new JsonSerializerSettings
            {
                Culture = new System.Globalization.CultureInfo("ru-Ru")
            };
            var result = new JsonResult(response)
            {
                StatusCode = (int)status,
                SerializerSettings = settings
            };
            return result;
        }
    }
}
