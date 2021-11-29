using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Domain.Entity
{
    [Table("Task")]
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int Author { get; set; }
        public int AssignedUser { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public int ProjectId { get; set; }

        public virtual File File { get; set; }
        public virtual Status Status { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Project Project { get; set; }
    }
}
