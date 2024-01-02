using System.ComponentModel.DataAnnotations;

namespace Goldie.Data
{
    public class Answer
    {
        public int AnswerId { get; set; }

        public int QuestionId { get; set;  }
        
        public Question? Question { get; set; }

        
        public int PlayerId { get; set; }
        
        public Player? Player { get; set; }

        [Required(ErrorMessage="You must choose an Answer!")]
        public string Choice { get; set; } = string.Empty;

    }
}
