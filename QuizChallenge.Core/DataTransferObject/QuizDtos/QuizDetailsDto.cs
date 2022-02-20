using QuizChallenge.Core.DataTransferObject.QuestionDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Core.DataTransferObject.QuizDtos
{
    public class QuizDetailsDto : ReadQuizDto
    {
        public List<ReadQuestionDto> readQuestions { get; set; }

    }
}
