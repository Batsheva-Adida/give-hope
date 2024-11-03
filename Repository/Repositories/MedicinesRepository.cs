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
    public class MedicinesRepository : IRepository<Medicines>
    {
        private readonly IContext _context;
        public MedicinesRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Medicines> addItemAsync(Medicines item)
        {
            await _context.medicines.AddAsync(item);
            await _context.save();
            return item;
        }

        public async Task deleteAsync(int id)
        {
            _context.medicines.Remove(await getAsync(id));
            await _context.save();
        }

        public async Task<List<Medicines>> getAllAsync()
        {
            return await _context.medicines.ToListAsync();
        }

        public async Task<Medicines> getAsync(int id)
        {
            return await _context.medicines.FirstOrDefaultAsync(x => x.Id == id);
        }
        //מקבל ID
        //public async Task<CustomersDto> sendMail(Customers customers)
        //{
        //    return mapper.Map<CustomersDto>(await repository.addItemAsync(firstName));
        //}
        public async Task updateAsync(int id, Medicines entity)
        {
            Medicines m = this._context.medicines.FirstOrDefault(x => x.Id == id);
            m.PriceMedicine = entity.PriceMedicine;
            m.NameMedication = entity.NameMedication;
            m.AmountOfMedicine = entity.AmountOfMedicine;
            m.DateMedication = entity.DateMedication;
            m.CategoryId = entity.CategoryId;
            m.CustomerId = entity.CustomerId;
            m.Recognized = entity.Recognized;
            m.RMail = entity.RMail;
            await Console.Out.WriteLineAsync(m.RMail);
            await _context.save();

        }
    }
}
