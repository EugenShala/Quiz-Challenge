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
        [Required]
        public string Text { get; set; }
        public int CorrectAnswerId { get; set; }


        public ICollection<Answer> Answers { get; set; }



        public int QuizId { get; set; }
        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }


    }
}
