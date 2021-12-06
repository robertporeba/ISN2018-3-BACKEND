using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Domain.Entity
{
    public class UserProject
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string UserName { get; set; }
    }
}
