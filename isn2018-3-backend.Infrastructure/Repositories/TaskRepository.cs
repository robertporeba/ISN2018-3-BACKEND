using isn2018_3_backend.Domain.Dto.Task;
using isn2018_3_backend.Domain.Interfaces;
using System;
using System.Collections.Generic;
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
                var taskDto = new GetTaskDto
                {
                    Id = task.Id,
                    Name = task.Name,
                    CreateDate = task.CreateDate,
                    Author = task.Author,
                    AssignedUser = task.AssignedUser,
                    StatusId = task.StatusId,
                    PriorityId = task.PriorityId,
                    ProjectId = task.ProjectId
                };
                tasksDtoList.Add(taskDto);
            }

            return tasksDtoList;
        }

        public GetTaskDto GetTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(a => a.Id == id);
            var taskDto = new GetTaskDto
            {
                Id = task.Id,
                Name = task.Name,
                CreateDate = task.CreateDate,
                Author = task.Author,
                AssignedUser = task.AssignedUser,
                StatusId = task.StatusId,
                PriorityId = task.PriorityId,
                ProjectId = task.ProjectId
            };
            return taskDto;
        }

        public string UpdateTask(AddTaskDto task)
        {
            throw new NotImplementedException();
        }
    }
}
