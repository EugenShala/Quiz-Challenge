using QuizChallenge.Core.Entities.QuizDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Core.Entities.AnswerDtos
{
    public class AnswerDto
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }

      //  public IEnumerable<Answer> Answers { get; set; }


        public int QuestionId { get; set; }
        [Required]
        public virtual Question Question { get; set; }


        public int? QuizId { get; set; }
        [Required]
        public virtual QuizDto Quiz { get; set; }

    }
}
