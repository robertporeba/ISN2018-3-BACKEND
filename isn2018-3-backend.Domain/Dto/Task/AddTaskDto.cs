using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Domain.Dto.Task
{
    public class AddTaskDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string AssignedUser { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public int ProjectId { get; set; }
    }
}
