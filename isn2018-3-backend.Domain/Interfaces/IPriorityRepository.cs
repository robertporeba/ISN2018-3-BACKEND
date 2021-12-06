using isn2018_3_backend.Domain.Dto.Priority;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Domain.Interfaces
{
    public interface IPriorityRepository
    {
        List<GetPriorityDto> GetAllPriorities();
        GetPriorityDto GetPriority(int id);
    }
}
