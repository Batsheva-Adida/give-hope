using Commont.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.interfaces
{
    public interface IService<T>
    {

        public Task<List<T>> getAllAsync();
        public Task<T> getAsync(int id);
        public Task deleteAsync(int id);
        public Task updateAsync(int id, T entity);
        public Task <T> AddAsync(T item);
        public Task save();
     
    }
}
