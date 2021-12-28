using isn2018_3_backend.Domain.Dto.Column;
using isn2018_3_backend.Domain.Dto.Priority;
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

namespace isn2018_3_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, User")]
    public class ColumnController : ControllerBase
    {
        private readonly IColumnRepository _columnRepository;

        public ColumnController(IColumnRepository columnRepository)
        {
            _columnRepository = columnRepository;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<GetColumnDto>> GetList(int id)
        {
            var model = _columnRepository.GetAllColumns(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("Add")]
        public ActionResult<string> Add([FromBody] AddColumnDto column)
        {
            var model = _columnRepository.AddColumn(column);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("Delete")]
        public ActionResult<string> Delete(int id)
        {
            var model = _columnRepository.DeleteColumn(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
    }
}
