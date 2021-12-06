using isn2018_3_backend.Domain.Dto.Priority;
using isn2018_3_backend.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, User")]
    public class PriorityController : ControllerBase
    {
        private readonly IPriorityRepository _priorityRepository;

        public PriorityController(IPriorityRepository priorityRepository)
        {
            _priorityRepository = priorityRepository;
        }

        [HttpGet("Get")]
        public ActionResult<GetPriorityDto> Get(int id)
        {
            var model = _priorityRepository.GetPriority(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("GetAll")]
        public ActionResult<List<GetPriorityDto>> GetList()
        {
            var model = _priorityRepository.GetAllPriorities();
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
    }
}
