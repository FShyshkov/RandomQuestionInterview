using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomQuestionInterview.QuestionServices.Contracts;
using RandomQuestionInterview.Models.Responses;
using RandomQuestionInterview.Models.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RandomQuestionInterview.Controllers
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {
        private readonly IQuestionService _questionService;
        
        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        // GET: api/<controller>   
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions(int? pageSize = 10, int? pageNumber = 1)
        {
            // Get response from business logic
            var response = await _questionService.GetAllQuestionsAsync((int)pageSize, (int)pageNumber);

            // Return as http response
            return response.ToHttpResponse();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // Get response from business logic
            var response = await _questionService.GetQuestionByIdAsync(id);

            // Return as http response
            return response.ToHttpResponse();
        }

        [HttpGet("Random")]
        public async Task<IActionResult> GetRandom()
        {
            var response = await _questionService.GetRandomQuestionAsync();
            return response.ToHttpResponse();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]QuestionRequest question)
        {
            var response = await _questionService.CreateQuestionAsync(question.QuestionText);
            return response.ToHttpResponse();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]QuestionRequest question)
        {
            var response = await _questionService.UpdateQuestionAsync(id, question.QuestionText);
            return response.ToHttpResponse();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _questionService.DeleteQuestionByIdAsync(id);
            return response.ToHttpResponse();
        }
    }
}
