using System.ComponentModel.DataAnnotations;

namespace ProjektZiotest.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string Nick { get; set; }
        public DateTime Date { get; set; }
        public int Result { get; set; }
        public List<TestQuestion>? TestQuestions { get; set; } // Relacja wiele do wielu z Question
    }
}
