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
    [Table("Column")]
    public class Column
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
    }
}
