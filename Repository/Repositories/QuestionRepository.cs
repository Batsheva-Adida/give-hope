using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private readonly IContext _context;
        public QuestionRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Question> addItemAsync(Question item)
        {
            await _context.question.AddAsync(item);
            await _context.save();
            return item;
        }

        public async Task deleteAsync(int id)
        {
            _context.question.Remove(await getAsync(id));
            await _context.save();
        }

        public async Task<List<Question>> getAllAsync()
        {
            return await _context.question.Include(m => m.Comments).ToListAsync();
        }

        public async Task<Question> getAsync(int id)
        {

            return await _context.question.Include(t => t.Comments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task updateAsync(int id, Question entity)
        {

            // _context.categories.Update(entity);
            //שונה אתמול בלילה 3 שורות
            Question q = this._context.question.FirstOrDefault(x => x.Id == id);
            q.Title = entity.Title;
            q.Body = entity.Body;
            q.Comments = entity.Comments;
            q.CreatedAt = entity.CreatedAt;

            //var category = await _context.categories.FirstOrDefaultAsync(x => x.Id == id);
            //category.NameCategory = entity.NameCategory;
            //  category.Id = entity.Id;
            await _context.save();
        
        }
  
    }
}
