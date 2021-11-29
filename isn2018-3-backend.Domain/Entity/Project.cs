using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Domain.Entity
{
    [Table("Project")]
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int Author { get; set; }

        public virtual Task Task { get; set; }
    }
}
