using Microsoft.EntityFrameworkCore;
using ProjektZiotest.IService;
using ProjektZiotest.Models;

namespace ProjektZiotest.BLL
{
    public class QuestionService : IQuestionService
    {
        private readonly QuizDB _context;

        public QuestionService(QuizDB context)
        {
            _context = context;
        }

        public Question GetQuestionById(int id)
        {
            try
            {
                return _context.Questions
                    .Where(q => q.Id == id)
                    .Select(q => new Question
                    {
                        Id = q.Id,
                        QuestionContent = q.QuestionContent,
                        CorrectAnswer = q.CorrectAnswer,
                        Answer1 = q.Answer1,
                        Answer2 = q.Answer2,
                        Answer3 = q.Answer3,
                        Answer4 = q.Answer4,
                        Reference = q.Reference,
                        TestQuestions = q.TestQuestions.Select(tq => new TestQuestion
                        {
                            TestId = tq.TestId
                        }).ToList()
                    })
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the question: " + ex.Message);
            }
        }

        public void AddQuestion(Question question)
        {
            try
            {
                question.Id = 0;
                _context.Questions.Add(question);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the question: " + ex.Message);
            }
        }

        public void UpdateQuestion(int id, Question updatedQuestion)
        {
            try
            {
                var question = _context.Questions.FirstOrDefault(q => q.Id == id);
                if (question != null)
                {
                    question.QuestionContent = updatedQuestion.QuestionContent;
                    question.CorrectAnswer = updatedQuestion.CorrectAnswer;
                    question.Answer1 = updatedQuestion.Answer1;
                    question.Answer2 = updatedQuestion.Answer2;
                    question.Answer3 = updatedQuestion.Answer3;
                    question.Answer4 = updatedQuestion.Answer4;
                    question.Reference = updatedQuestion.Reference;

                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Question not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the question: " + ex.Message);
            }
        }

        public void DeleteQuestion(int id)
        {
            try
            {
                var question = _context.Questions.FirstOrDefault(q => q.Id == id);
                if (question != null)
                {
                    _context.Questions.Remove(question);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Question not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the question: " + ex.Message);
            }
        }

        public List<Question> GetAllQuestions()
        {
            try
            {
                return _context.Questions
                    .Select(q => new Question
                    {
                        Id = q.Id,
                        QuestionContent = q.QuestionContent,
                        CorrectAnswer = q.CorrectAnswer,
                        Answer1 = q.Answer1,
                        Answer2 = q.Answer2,
                        Answer3 = q.Answer3,
                        Answer4 = q.Answer4,
                        Reference = q.Reference,
                        TestQuestions = q.TestQuestions.Select(tq => new TestQuestion
                        {
                            TestId = tq.TestId
                        }).ToList()
                    }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all questions: " + ex.Message);
            }
        }
    }
}
