using QuizChallenge.Core.Entities.AnswerDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Core.Entities.QuizDtos
{
    public class QuizDto
    {
        public QuizDto()
        {
            Questions = new List<Question>();
            Answers = new List<AnswerDto>();  
        }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

       public List<Question> Questions { get; set; }
       public List<AnswerDto> Answers { get; set; }

    }
}
 