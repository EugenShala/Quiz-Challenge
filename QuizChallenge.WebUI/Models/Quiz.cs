using System.ComponentModel.DataAnnotations;

namespace QuizChallenge.WebUI.Models
{
    public class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
        }


        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
