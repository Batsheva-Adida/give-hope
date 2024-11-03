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
    public class CommentsRepository : IRepository<Comments>
    {
        private readonly IContext _context;
        public CommentsRepository(IContext context)
        {
            this._context = context;
        }
        public async Task<Comments> addItemAsync(Comments item)
        {
        await _context.comments.AddAsync(item);
            await _context.save();
            return item;
        }

        public async Task deleteAsync(int id)
        {
            _context.comments.Remove(await getAsync(id));
            await _context.save();
        }

        public async Task<List<Comments>> getAllAsync()
        {
            return await _context.comments.Include(x=>x.User).ToListAsync();
        }

        public async Task<Comments> getAsync(int id)
        {
            return await _context.comments.FirstOrDefaultAsync(x => x.Id == id);        }

        public async Task updateAsync(int id, Comments entity)
        {
            Comments c=this._context.comments.FirstOrDefault(x=>x.Id==id);
            c.QuestionId = entity.QuestionId;
            c.Id = entity.Id;
            c.UserId = entity.UserId;
            c.Content = entity.Content;
            await this._context.save();
        }
    }
}
