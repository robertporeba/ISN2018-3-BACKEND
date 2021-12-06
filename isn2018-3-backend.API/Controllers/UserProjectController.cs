using isn2018_3_backend.Domain.Dto.UserProject;
using isn2018_3_backend.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isn2018_3_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserProjectController : ControllerBase
    {
        private readonly IUserProjectRepository _userProjectRepository;

        public UserProjectController(IUserProjectRepository userProjectRepository)
        {
            _userProjectRepository = userProjectRepository;
        }

        [HttpPost("Add")]
        public ActionResult<string> Add([FromBody] UserProjectDto userProjectDto)
        {
            var model = _userProjectRepository.AddUserProject(userProjectDto);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("GetAll")]
        public ActionResult<List<UserProjectDto>> GetList(int id)
        {
            var model = _userProjectRepository.GetAllUsersProject(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("Delete")]
        public ActionResult<string> Delete([FromBody] UserProjectDto userProject)
        {
            var model = _userProjectRepository.DeleteserProject(userProject);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
    }
}
