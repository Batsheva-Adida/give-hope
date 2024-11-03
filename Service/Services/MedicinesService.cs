using AutoMapper;
using Commont.Dto;
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
    public class MedicinesService : IService<MedicinesDto>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Medicines> repository;

        public MedicinesService(IMapper mapper, IRepository<Medicines> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<MedicinesDto> AddAsync(MedicinesDto item)
        {
            Medicines m=mapper.Map<Medicines>(item);
            return mapper.Map<MedicinesDto>(await repository.addItemAsync(mapper.Map<Medicines>(item)));
        }

        public async Task deleteAsync(int id)
        {
            await repository.deleteAsync(id);
        }

        public async Task<List<MedicinesDto>> getAllAsync()
        {
            return mapper.Map<List<MedicinesDto>>(await repository.getAllAsync());
        }

        public async Task <MedicinesDto> getAsync(int id)
        {
            return mapper.Map<MedicinesDto>(await repository.getAsync(id));
        }

        public Task<CustomersDto> GetUserByUserEmail(string firstName)
        {
            throw new NotImplementedException();
        }

        public async Task save()
        {
            save();
        }

        public async Task updateAsync(int id, MedicinesDto entity)
        {
            await repository.updateAsync(id, mapper.Map<Medicines>(entity));
         }

   
    }
}
