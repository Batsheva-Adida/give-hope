using Commont.Dto;
using Commont.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.interfaces;

namespace Progect_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController:ControllerBase
    {

        private readonly IService<CommentsDto> service;

        public CommentsController(IService<CommentsDto> service)
        {
            this.service = service;
        }

        [HttpGet]
        //[Authorize]
        public async Task<List<CommentsDto>> Get()
        {
            //GetCurrentUser();
            return await service.getAllAsync();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<CommentsDto> Get(int id)
        {
            return await service.getAsync(id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CommentsDto categories)
        {
            return Ok(await service.AddAsync(categories));
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CommentsDto c)
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
