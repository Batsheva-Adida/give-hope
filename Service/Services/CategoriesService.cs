using AutoMapper;
using Commont.Entity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Repository.Entity;
using Repository.Interface;
using Service.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoriesService : IService<CategoriesDto>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Categories> repository;
        public CategoriesService(IRepository<Categories> repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<CategoriesDto> AddAsync(CategoriesDto entity)
        {
            Categories c=mapper.Map<Categories>(entity);
            return mapper.Map<CategoriesDto>( await repository.addItemAsync(mapper.Map<Categories>(entity)));
        }

        public async Task deleteAsync(int id)
        {
            await repository.deleteAsync(id);
        }

        public async Task<List<CategoriesDto>> getAllAsync()
        {
            return mapper.Map<List<CategoriesDto>>(await repository.getAllAsync());    
        }
        
        public async Task<CategoriesDto> getAsync(int id)
        {
            return mapper.Map<CategoriesDto>(await repository.getAsync(id));
        }
        public async Task updateAsync(int id, CategoriesDto entity)
        {
            await repository.updateAsync(id, mapper.Map<Categories>(entity));
        }

        public async Task save()
        {
            save();
        }

        public Task<CustomersDto> GetUserByUserEmail(string firstName)
        {
            throw new NotImplementedException();
        }
    }

}

      