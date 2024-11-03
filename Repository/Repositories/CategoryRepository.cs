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
    public class CategoryRepository : IRepository<Categories>
    {
        private readonly IContext _context;
        public CategoryRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Categories> addItemAsync(Categories item)
        {
            await _context.categories.AddAsync(item);
            await _context.save();
            return item;
        }

        public async Task deleteAsync(int id)
        {
            _context.categories.Remove(await getAsync(id));
            await _context.save();
        }

        public async Task<List<Categories>> getAllAsync()
        {
            return await _context.categories.Include(m => m.MedicinesInCategory).ToListAsync();
        }

        public async Task<Categories> getAsync(int id)
        {
            return await _context.categories.FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task updateAsync(int id, Categories entity)
        {
            // _context.categories.Update(entity)
            Categories c = this._context.categories.FirstOrDefault(x => x.Id == id);
            c.NameCategory = entity.NameCategory;
            c.MedicinesInCategory = entity.MedicinesInCategory;

            //var category = await _context.categories.FirstOrDefaultAsync(x => x.Id == id);
            //category.NameCategory = entity.NameCategory;
            //  category.Id = entity.Id;

            await this._context.save();
        }


    }
}