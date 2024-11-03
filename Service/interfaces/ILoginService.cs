using Commont.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.interfaces
{
    public interface ILoginService:IService<CustomersDto>
    {
        public CustomersDto Login(string email, int password);
    }
}
