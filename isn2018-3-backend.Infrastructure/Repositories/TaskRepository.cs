using isn2018_3_backend.Domain.Dto.Task;
using isn2018_3_backend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IsnContext _context;

        public TaskRepository(IsnContext context)
        {
            _context = context;
        }

        public int AddTask(AddTaskDto task)
        {
            var time = DateTime.Now;
            var taskToSave = new Domain.Entity.Task
            {
                Name = task.Name,
                CreateDate = time,
                Description= "",
                FileName = "",
                Author = task.Author,
                AssignedUser = task.AssignedUser,
                StatusId = task.StatusId,
                PriorityId = task.PriorityId,
                ProjectId = task.ProjectId
            };

            _context.Tasks.Add(taskToSave);
            _context.SaveChanges();
            var id = _context.Tasks.FirstOrDefault(x => x.CreateDate == time).Id;
            return id;
        }

        public string ChangeStatus(TaskStatusDto taskStatus)
        {
            var task = _context.Tasks.FirstOrDefault(x => x.Id == taskStatus.Id);
            task.StatusId = taskStatus.StatusId;
            _context.SaveChanges();
            return "Ok";
        }

        public string DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
                return "ok";
            }
            return null;
        }

        public List<GetTaskDto> GetAllTasks(int id)
        {
            var tasks = _context.Tasks.Where(x => x.ProjectId == id).ToList();
            var tasksDtoList = new List<GetTaskDto>();
            foreach (Domain.Entity.Task task in tasks)
            {
                var priorityName = _context.Priorities.FirstOrDefault(x => x.Id == task.PriorityId).Name;
                var taskDto = new GetTaskDto
                {
                    Id = task.Id,
                    Name = task.Name,
                    CreateDate = task.CreateDate,
                    Author = task.Author,
                    FileName = task.FileName,
                    Description = task.Description,
                    AssignedUser = task.AssignedUser,
                    StatusId = task.StatusId,
                    PriorityId = task.PriorityId,
                    ProjectId = task.ProjectId,
                    PriorityName=priorityName,

                };
                tasksDtoList.Add(taskDto);
            }

            return tasksDtoList;
        }

        public GetTaskDto GetTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(a => a.Id == id);
            var priorityName = _context.Priorities.FirstOrDefault(x => x.Id == task.PriorityId).Name;
            var taskDto = new GetTaskDto
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                CreateDate = task.CreateDate,
                Author = task.Author,
                FileName = task.FileName,
                AssignedUser = task.AssignedUser,
                StatusId = task.StatusId,
                PriorityId = task.PriorityId,
                ProjectId = task.ProjectId,
                PriorityName = priorityName,
            };
            return taskDto;
        }

        public string UpdateTask(UpdateTaskDto taskDto)
        {
            //var path = Path.GetFileName(taskDto.FileName);
            var task = _context.Tasks.FirstOrDefault(x => x.Id == taskDto.Id);
            task.Name = taskDto.Name;
            task.AssignedUser = taskDto.AssignedUser;
            task.PriorityId = taskDto.PriorityId;
            task.Description = taskDto.Description;
            task.FileName = taskDto.FileName;
            _context.SaveChanges();
            return "Ok";
        }
    }
}
