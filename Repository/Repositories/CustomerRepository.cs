using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Repository.Repositories
{
    public class CustomerRepository : ILogin
    {
        private readonly IContext _context;
        public CustomerRepository(IContext context)
        {
            _context = context;
        }
       
        public async Task<Customers> addItemAsync(Customers item)
        {

             Customers customers = item;
             //if (!await IsValidEmail(customers.Email))
             //{
             //    // טפל במייל לא תקין (לדוגמא: זרוק חריג או הצג הודעת שגיאה)
             //    
             //}
             var existingCustomer = await _context.customers.FirstOrDefaultAsync(c => c.Email == item.Email);

            if (existingCustomer != null)
            {
                throw new Exception("כתובת מייל זו כבר קיימת במערכת");
                //await Console.Out.WriteLineAsync("כתובת מייל זו כבר קיימת במערכת");
                //var error = new { message = "כתובת מייל זו כבר קיימת במערכת" };
                //return null; // לא להוסיף לקוח
            }
            await _context.customers.AddAsync(item);
            await _context.save();
            return item;
        }

        public async Task deleteAsync(int id)
        {
            _context.customers.Remove(await getAsync(id));
            await _context.save();
        }

        public async Task<List<Customers>> getAllAsync()
        {
            return await _context.customers.ToListAsync();
        }

        public async Task<Customers> getAsync(int id)
        {
            return await _context.customers.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task updateAsync(int id, Customers entity)
        {
            Customers c = this._context.customers.FirstOrDefault(x => x.Id == id);
            c.FirstName = entity.FirstName;
            c.LastName = entity.LastName;
            c.Email = entity.Email;
            c.Password = entity.Password;
            await _context.save();
        }
        public Customers getCustomerByLogin(string email, int password)
        {
            Customers c=this._context.customers.FirstOrDefault(x=>x.Email==email && x.Password==password);
            if(c!=null)
                return c;
            return null;
        }
    }
}
