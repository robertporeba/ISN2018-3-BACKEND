﻿using isn2018_3_backend.Domain.Dto.Task;
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
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpPost("Add")]
        public ActionResult<string> Add([FromBody] AddTaskDto projectDto)
        {
            var model = _taskRepository.AddTask(projectDto);
            return Ok(model);
        }

        [HttpPost("Delete")]
        public ActionResult<string> Delete(int id)
        {
            var model = _taskRepository.DeleteTask(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("Get")]
        public ActionResult<GetTaskDto> Get(int id)
        {
            var model = _taskRepository.GetTask(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("GetAll")]
        public ActionResult<List<GetTaskDto>> GetList(int id)
        {
            var model = _taskRepository.GetAllTasks(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("ChangeStatus")]
        public ActionResult<string> ChangeStatus([FromBody] TaskStatusDto taskStatus)
        {
            var response = _taskRepository.ChangeStatus(taskStatus);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost("Update")]
        public ActionResult<string> Update([FromBody] UpdateTaskDto task)
        {
            var response = _taskRepository.UpdateTask(task);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
