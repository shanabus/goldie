using Goldie.Data;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

namespace Goldie.Services
{
    public class PlayerService
    {
        public IDbContextFactory<GoldieDbContext> DbFactory;
        public readonly GoldieDbContext _context;

        public PlayerService(IDbContextFactory<GoldieDbContext> dbFactory)
        {
            _context = dbFactory.CreateDbContext();
        }

        public async Task<Player> SavePlayerAsync(string name)
        {
            var player = new Player();
            player.Name = name;

            await _context.Players.AddAsync(player);

            await _context.SaveChangesAsync();

            return player;
        }

        public async Task<Player> GetPlayerById(int id)
        {
            var player = await _context.Players.Include(x => x.Answers).Where(x => x.PlayerId == id).FirstOrDefaultAsync();

            return player;
        }

        public async Task<Player> GetPlayerByName(string name)
        {
            var player = await _context.Players.Where(x => x.Name == name).FirstOrDefaultAsync();

            return player;
        }

        public async Task<int> GetPlayerScoreAsync(int playerId)
        {
            int score = 0; 

            var player = await GetPlayerById(playerId);

            var questions = await _context.Questions.ToListAsync();

            foreach (var answer in player.Answers)
            {
                var q = questions.Where(x => x.QuestionId == answer.QuestionId).FirstOrDefault();

                if (q != null && q.CorrectChoice == answer.Choice)
                {
                    score += 100;
                }
            }

            return score;
        }

        public async Task<List<PlayerScore>> GetAllPlayerScoresAsync()
        {
            var playerScores = new List<PlayerScore>();

            var players = await _context.Players.Include(x => x.Answers).ToListAsync();

            foreach(var player in players)
            {
                int score = 0;

                var questions = await _context.Questions.ToListAsync();

                foreach (var answer in player.Answers)
                {
                    var q = questions.Where(x => x.QuestionId == answer.QuestionId).FirstOrDefault();

                    if (q != null && q.CorrectChoice == answer.Choice)
                    {
                        score += 100;
                    }
                }

                playerScores.Add(new PlayerScore { Name  = player.Name, Score = score, Answers = player.Answers.Count, TimeCompleted = player.TimeComplete });
            }

            return playerScores;
        }

        public async Task<DateTime> PlayerHasFinishedAsync(int playerId)
        {
            var dt = DateTime.Now;
            var player = await _context.Players.SingleOrDefaultAsync(x => x.PlayerId == playerId);
            player.TimeComplete = dt;

            await _context.SaveChangesAsync();

            return dt;

        }
    }
}
