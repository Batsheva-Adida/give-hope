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
    public class QuestionService : IService<QuestionDto>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Question> repository;

        public QuestionService(IMapper mapper, IRepository<Question> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
    
        public async Task<QuestionDto> AddAsync(QuestionDto item)
        {
            // Question q=mapper.Map<Question>(item);
            Question q = this.mapper.Map<Question>(item) ;
            var a = await repository.addItemAsync(q);

            return mapper.Map<QuestionDto>(a);
        }

        public Task deleteAsync(int id)
        {
            return repository.deleteAsync(id);
        }

        public async Task<List<QuestionDto>> getAllAsync()
        {
            return mapper.Map<List<QuestionDto>>(await repository.getAllAsync());
        } 
        public async Task<QuestionDto> getAsync(int id)
        {
            return mapper.Map<QuestionDto>(await repository.getAsync(id));
        }

        public async Task save()
        {
            save();        }

        public Task updateAsync(int id, QuestionDto entity)
        {
            throw new NotImplementedException();
        }
    }
    }

 

