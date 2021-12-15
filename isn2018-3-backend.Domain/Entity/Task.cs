using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Index = Microsoft.EntityFrameworkCore.Metadata.Internal.Index;

namespace isn2018_3_backend.Domain.Entity
{
    [Table("Task")]
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string Author { get; set; }
        public string AssignedUser { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public int ProjectId { get; set; }

        public virtual ICollection<File> File { get; set; }
        public virtual ICollection<Status> Status { get; set; }
        public virtual ICollection<Priority> Priority { get; set; }
        public virtual ICollection<Project> Project { get; set; }
    }
}
