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
        public string AddTask(Domain.Entity.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return "ok";
        }
    }
}
