using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Core.Entities
{
    public partial class Answer
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }

      //  public IEnumerable<Answer> Answers { get; set; }


        public int QuestionId { get; set; }
        [Required]
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }


        //public int? QuizId { get; set; }
        //[Required]
        //[ForeignKey("QuizId")]
        //public virtual Quiz Quiz { get; set; }

    }
}
