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
    public class CommentsService : IService<CommentsDto>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Comments> repository;
        
        public CommentsService(IRepository<Comments> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<CommentsDto> AddAsync(CommentsDto item)
        {
            Comments c = mapper.Map<Comments>(item);
            return mapper.Map<CommentsDto>(await repository.addItemAsync(mapper.Map<Comments>(item)));
        }

        public async Task deleteAsync(int id)
        {
            await repository.deleteAsync(id);
        }

        public async Task<List<CommentsDto>> getAllAsync()
        {
            return mapper.Map<List<CommentsDto>>(await repository.getAllAsync());
        } 
        public async Task<CommentsDto> getAsync(int id)
        {
            return mapper.Map<CommentsDto>(await repository.getAsync(id));
        }

        public async Task save()
        {
            save();   
        }

        public Task updateAsync(int id, CommentsDto entity)
        {
            throw new NotImplementedException();
        }
    }
    }

  

