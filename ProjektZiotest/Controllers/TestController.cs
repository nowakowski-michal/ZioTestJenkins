using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektZiotest.BLL;
using ProjektZiotest.IService;
using ProjektZiotest.Models;

namespace ProjektZiotest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet("{id}")]
        public ActionResult<Test> GetTestById(int id)
        {
            try
            {
                var test = _testService.GetTestById(id);
                if (test == null)
                {
                    return NotFound();
                }
                return test;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        public ActionResult<List<Test>> GetAllTests()
        {
            try
            {
                return _testService.GetAllTests();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Test> AddTest(Test test)
        {
            try
            {
                test.Id = 0;
                _testService.AddTest(test);
                return CreatedAtAction(nameof(GetTestById), new { id = test.Id }, test);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTest(int id, Test updatedTest)
        {
            try
            {
                _testService.UpdateTest(id, updatedTest);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTest(int id)
        {
            try
            {
                _testService.DeleteTest(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("nick/{nick}/date/{date}")]
        public ActionResult<Test> GetTestByNickAndDate(string nick, DateTime date)
        {
            try
            {
                var test = _testService.GetTestByNickAndDate(nick, date);
                if (test == null)
                {
                    return NotFound();
                }
                return test;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("user/{nick}")]
        public ActionResult<List<Test>> GetTestsByUser(string nick)
        {
            try
            {
                var tests = _testService.GetTestsByUser(nick);
                return tests;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}/add-questions")]
        public IActionResult AddQuestionsToList(int id, List<int> questions)
        {
            try
            {
                _testService.AddQuestionsToList(id, questions);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
