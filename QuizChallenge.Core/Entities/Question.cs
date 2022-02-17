using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Core.Entities
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



        [Required]
        public int? QuizId { get; set; }
        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }

       

    }
}
