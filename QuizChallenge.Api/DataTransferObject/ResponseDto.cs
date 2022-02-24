using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Api.DataTransferObject
{
    public class ResponseDto
    {
        public bool Success { get; set; } = true;
        public List<string> Error { get; set; }
        public string Message { get; set; } = "";
        public object Result { get; set; }
    }
}
