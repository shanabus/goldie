namespace Goldie.Data
{
    public class Player
    {
        public int PlayerId { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<Answer> Answers { get; set; } = new List<Answer>();

        public DateTime TimeComplete { get; set; }
    }
}
