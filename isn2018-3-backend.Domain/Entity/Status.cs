using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Domain.Entity
{
    [Table("Status")]
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
