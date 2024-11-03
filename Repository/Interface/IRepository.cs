using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entity;
using Repository.Repositories;

namespace Repository.Interface
{
    public interface IRepository<T> 
    {
        public Task<List<T>> getAllAsync();
        public Task<T> getAsync(int id);
        public Task deleteAsync(int id);
        public Task updateAsync(int id,T entity);
        public Task<T> addItemAsync(T item);
      //  Task<object> addItemAsync(Question question);
    }
}
