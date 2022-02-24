using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Api.DataTransferObject.AnswerDtos
{
    public class AnswerDetailsDto : BaseDto
    {
        public string Text { get; set; }
        public int QuestionId { get; set; }

    }
}
