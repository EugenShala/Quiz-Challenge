using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Core.DataTransferObject.QuestionDtos
{
    public class CreateQuestionDto
    {
        [Required]
        [StringLength(80)]
        public string Text { get; set; }
        public int CorrectAnswerId { get; set; }
        [Required]
        public int QuizId { get; set; }

    }
}
