using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Core.Entities
{
    public class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
            //  Answers = new HashSet<Answer>();  
        }

        [Key]
        public int QuizId { get; set; }
        [Required]
        public string Title { get; set; }

       public ICollection<Question> Questions { get; set; }
      // public ICollection<Answer> Answers { get; set; }

    }
}
 