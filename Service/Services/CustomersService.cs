using AutoMapper;
using Commont.Entity;
using Repository.Entity;
using Repository.Interface;
using Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CustomersService : ILoginService
    {
        private readonly IMapper mapper;
        private readonly ILogin repository;
        public CustomersService(ILogin repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<CustomersDto> AddAsync(CustomersDto item)
        {
            Customers c = mapper.Map<Customers>(item);
            return mapper.Map<CustomersDto>(await repository.addItemAsync(mapper.Map<Customers>(item)));
        }
        public async Task deleteAsync(int id)
        {
            await repository.deleteAsync(id);
        }

        public async Task<List<CustomersDto>> getAllAsync()
        {
            return mapper.Map<List<CustomersDto>>(await repository.getAllAsync());
        }

        public async Task<CustomersDto> getAsync(int id)
        {
            return mapper.Map<CustomersDto>(await repository.getAsync(id));
        }

        public async Task updateAsync(int id, CustomersDto entity)
        {
            await repository.updateAsync(id, mapper.Map<Customers>(entity));
        }

        //public async Task<CustomersDto> GetUserByUserEmail(CustomersDto firstName)
        //{
        //    // ודא ש-item מכיל נתונים תקינים מסוג CustomersDto

        //    //Customers customer = mapper.Map<Customers>(item);
        //    return mapper.Map<CustomersDto>(await repository.addItemAsync(firstName));

        //    // ... המשך הקוד
        //}
      

        public async Task save()
        {
            save();
        }

        public CustomersDto Login(string email, int password)
        {
         return mapper.Map<CustomersDto>( repository.getCustomerByLogin(email,password));
        }
    }
}
