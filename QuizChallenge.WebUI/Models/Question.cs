using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizChallenge.WebUI.Models
{
    public class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Please fill Text Area")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Please fill CorrectAnswerId Area")]
        public int CorrectAnswerId { get; set; }


        public ICollection<Answer> Answers { get; set; }


        [Required]
        public int QuizId { get; set; }
        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }


    }
}
