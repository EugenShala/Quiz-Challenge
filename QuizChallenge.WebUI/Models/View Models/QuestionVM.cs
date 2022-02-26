namespace QuizChallenge.WebUI.Models.View_Models
{
    public class QuestionVM
    {
        public Question Questions { get; set; }
        public Answer Answer { get; set; }
        public IEnumerable<Answer> Answers { get; set; }   
    }
}
