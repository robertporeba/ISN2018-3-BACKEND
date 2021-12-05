using isn2018_3_backend.Domain.Entity;
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
using isn2018_3_backend.Domain.Dto.Project;

namespace isn2018_3_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpPost("Add")]
        public ActionResult<string> Add([FromBody] AddProjectDto projectDto)
        {
            var model = _projectRepository.AddProject(projectDto);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("Delete")]
        public ActionResult<string> Delete(int id)
        {
            var model = _projectRepository.DeleteProject(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("Get")]
        public ActionResult<GetProjectDto> Get(int id)
        {
            var model = _projectRepository.GetProject(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("GetAll")]
        public ActionResult<List<GetProjectDto>> GetList()
        {
            var model = _projectRepository.GetAllProjects();
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
    }
}
