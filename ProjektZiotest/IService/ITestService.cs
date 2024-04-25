using ProjektZiotest.Models;

namespace ProjektZiotest.IService
{
    public interface ITestService
    {
        Test GetTestById(int id);
        void AddTest(Test test);
        void UpdateTest(int id, Test updatedTest);
        void DeleteTest(int id);
        List<Test> GetAllTests();
        Test GetTestByNickAndDate(string nick, DateTime date);
        List<Test> GetTestsByUser(string nick);
        void AddQuestionsToList(int testId, List<int> questions);
    }
}
