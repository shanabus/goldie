using Goldie.Data;
using Microsoft.EntityFrameworkCore;

namespace Goldie.Services
{
    public class QuestionService
    {
        public IDbContextFactory<GoldieDbContext> DbFactory;
        public readonly GoldieDbContext _context;

        public QuestionService(IDbContextFactory<GoldieDbContext> dbFactory)
        {
            _context = dbFactory.CreateDbContext();
        }

        public async Task<Question> GetQuestionAsync(string token)
        {
            var question = await _context.Questions.SingleOrDefaultAsync(x => x.QuestionToken == token);

            return question;
        }

        public async Task<List<Question>> GetAllQuestionAsync()
        {
            var questions = await _context.Questions.ToListAsync();

            return questions;
        }
    }
}
