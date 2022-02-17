using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Core.DataTransferObject.QuizDtos
{
    public class UpdateQuizDto : BaseDto
    {
        [Required]
        [StringLength(20)]
        public string Title { get; set; }
    }
}
