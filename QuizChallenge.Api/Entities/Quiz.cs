using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Api.Entities
{
    public class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
        }


        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

       public ICollection<Question> Questions { get; set; }

    }
}
 