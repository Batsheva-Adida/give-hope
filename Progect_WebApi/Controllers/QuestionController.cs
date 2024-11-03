using Commont.Dto;
using Commont.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.interfaces;

namespace Progect_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController:ControllerBase
    {
        private readonly IService<QuestionDto> service;

        public QuestionController(IService<QuestionDto> service)
        {
            this.service = service;
        }

        [HttpGet]
        //[Authorize]
        public async Task<List<QuestionDto>> Get()
        {
            //GetCurrentUser();
            return await service.getAllAsync();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<QuestionDto> Get(int id)
        {
            return await service.getAsync(id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] QuestionDto categories)
        {
            return Ok(await service.AddAsync(categories));
        }


        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] QuestionDto c)
        {
            await service.updateAsync(id, c);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.deleteAsync(id);
        }
    }
}
