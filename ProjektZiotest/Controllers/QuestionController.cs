using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektZiotest.BLL;
using ProjektZiotest.IService;
using ProjektZiotest.Models;

namespace ProjektZiotest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("{id}")]
        public ActionResult<Question> GetQuestionById(int id)
        {
            try
            {
                var question = _questionService.GetQuestionById(id);
                if (question == null)
                {
                    return NotFound();
                }
                return question;
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Question> AddQuestion(Question question)
        {
            try
            {
                question.Id = 0;
                _questionService.AddQuestion(question);
                return CreatedAtAction(nameof(GetQuestionById), new { id = question.Id }, question);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateQuestion(int id, Question updatedQuestion)
        {
            try
            {
                _questionService.UpdateQuestion(id, updatedQuestion);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(int id)
        {
            try
            {
                _questionService.DeleteQuestion(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Question>> GetAllQuestions()
        {
            try
            {
                return _questionService.GetAllQuestions();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
