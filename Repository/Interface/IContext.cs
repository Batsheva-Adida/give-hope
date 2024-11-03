using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IContext
    {
        public DbSet<Categories> categories { get; set; }
        public DbSet<Customers> customers { get; set; }
        public DbSet<Medicines> medicines { get; set; }

        public DbSet<Comments> comments { get; set; }

        public DbSet<Question> question { get; set; }   
        public Task save();
    }
}
