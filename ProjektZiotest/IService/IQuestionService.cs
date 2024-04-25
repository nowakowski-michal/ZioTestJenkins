using ProjektZiotest.Models;

namespace ProjektZiotest.IService
{
    public interface IQuestionService
    {
        Question GetQuestionById(int id);
        void AddQuestion(Question question);
        void UpdateQuestion(int id, Question updatedQuestion);
        void DeleteQuestion(int id);
        List<Question> GetAllQuestions();
    }
}
