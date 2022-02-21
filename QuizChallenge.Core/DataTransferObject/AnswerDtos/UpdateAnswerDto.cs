using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Core.DataTransferObject.AnswerDtos
{
    public class UpdateAnswerDto : BaseDto
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public int QuestionId { get; set; }
    }
}
