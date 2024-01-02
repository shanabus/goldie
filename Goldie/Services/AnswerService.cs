using Goldie.Data;
using Microsoft.EntityFrameworkCore;

namespace Goldie.Services
{
    public class AnswerService
    {
        public IDbContextFactory<GoldieDbContext> DbFactory;
        public readonly GoldieDbContext _context;

        public AnswerService(IDbContextFactory<GoldieDbContext> dbFactory)
        {
            _context = dbFactory.CreateDbContext();
        }

        public async Task<Answer> SubmitAnswerAsync(Answer answer)
        {
            _context.Answers.Add(answer);

            await _context.SaveChangesAsync();

            return answer;
        }
    }
}
