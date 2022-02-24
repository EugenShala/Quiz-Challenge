using QuizChallenge.Core.DataTransferObject.AnswerDtos;
using QuizChallenge.Core.DataTransferObject.QuizDtos;
using QuizChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Core.DataTransferObject.QuestionDtos
{
    public class QuestionDto
    {
        public QuestionDto()
        {
            Answers = new HashSet<AnswerDto>();
        }

        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public int CorrectAnswerId { get; set; }


        public ICollection<AnswerDto> Answers { get; set; }


        [Required]
        public int QuizId { get; set; }
        public virtual QuizDto Quiz { get; set; }
    }
}
