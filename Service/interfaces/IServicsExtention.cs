using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.interfaces
{
    internal interface IServicsExtention<T>:IService<T>
    {
        public Task<T> getUserbyUserMail(string Email, int Password);
    }
}
