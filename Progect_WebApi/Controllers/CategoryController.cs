using Commont.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.interfaces;
using System.Security.Claims;

namespace Progect_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CategoryController:ControllerBase
    {
        private readonly IService<CategoriesDto> service;

        public CategoryController(IService<CategoriesDto> service)
        {
            this.service = service;
        }
        [HttpGet]
        [Authorize]
        //private CustomersDto GetCurrentUser()
        //{
        //    var identity = HttpContext.User.Identity as ClaimsIdentity;
        //    if (identity != null)
        //    {
        //        var userId = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        //        var UserClaim = identity.Claims;
        //        if (userId != null)
        //        {
        //            return new CustomersDto()
        //            {
        //                Id = int.Parse(userId),
        //                //Id=UserClaim.FirstOrDefault(x=>x.Type==ClaimTypes.NameIdentifier)?.Value,
        //                FirstName = UserClaim.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value,
        //                Email = UserClaim.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
        //                LastName = UserClaim.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value,
        //            };
        //        }
        //    }
        //    return null;
        //}
        public async Task<List<CategoriesDto>> Get()
        {
            //GetCurrentUser();
            return await service.getAllAsync();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<CategoriesDto> Get(int id)
        {
            return await service.getAsync(id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task <ActionResult> Post([FromBody] CategoriesDto categories)
        {
          return Ok(  await service.AddAsync(categories));
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CategoriesDto c)
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


