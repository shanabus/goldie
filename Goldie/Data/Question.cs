namespace Goldie.Data
{
    public class Question {
        public int QuestionId { get; set; }
        public string QuestionToken { get; set; } = string.Empty;
        public string QuestionText { get; set; } = string.Empty;

        public string Choice1 { get; set; } = string.Empty;        
        public string Choice2 {  get; set; } = string.Empty;
        public string Choice3 {  get; set; } = string.Empty;
        public string Choice4 { get; set; } = string.Empty;

        public string CorrectChoice { get; set; } = string.Empty;
    }
}
