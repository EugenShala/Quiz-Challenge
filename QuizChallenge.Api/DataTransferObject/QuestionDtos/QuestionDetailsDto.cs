using QuizChallenge.Api.DataTransferObject.AnswerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Api.DataTransferObject.QuestionDtos
{
    public class QuestionDetailsDto : ReadQuestionDto
    {
        public string Text { get; set; }
        public int CorrectAnswerId { get; set; }
        public int QuizId { get; set; }


        public List<ReadAnswerDto> readAnswers { get; set; }
    }
}
