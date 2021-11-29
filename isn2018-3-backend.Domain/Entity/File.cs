using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Domain.Entity
{
    [Table("File")]
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TaskId { get; set; }

        public virtual Task Task { get; set; }
    }
}
