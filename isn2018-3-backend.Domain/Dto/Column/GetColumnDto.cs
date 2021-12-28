using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Domain.Dto.Column
{
    public class GetColumnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
    }
}
