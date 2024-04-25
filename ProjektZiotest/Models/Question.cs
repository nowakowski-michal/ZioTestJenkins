using System.ComponentModel.DataAnnotations;

namespace ProjektZiotest.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string QuestionContent { get; set; }
        public int CorrectAnswer { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string Reference { get; set; }
        public List<TestQuestion>? TestQuestions { get; set; }

    }
}
