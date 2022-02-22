using QuizChallenge.Core.DataTransferObject.AnswerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Core.DataTransferObject.QuestionDtos
{
    public class DeleteQuestionDto : BaseDto
    {
        public string Text { get; set; }
        public int CorrectAnswerId { get; set; }
        public int QuizId { get; set; }
    }
}
