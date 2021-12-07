using isn2018_3_backend.Domain.Dto.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Domain.Interfaces
{
    public interface ITaskRepository
    {
        string AddTask(AddTaskDto task);
        string UpdateTask(AddTaskDto task);
        string DeleteTask(int id);
        GetTaskDto GetTask(int id);
        List<GetTaskDto> GetAllTasks(int id);
    }
}
