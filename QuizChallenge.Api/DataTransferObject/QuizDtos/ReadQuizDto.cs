using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Api.DataTransferObject.QuizDtos
{
    public class ReadQuizDto : BaseDto
    {
        public string Title { get; set; }
    }
}
