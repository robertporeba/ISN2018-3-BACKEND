using isn2018_3_backend.Domain.Dto.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Domain.Interfaces
{
    public interface IStatusRepository
    {
        List<GetStatusDto> GetAllStatuses();
        GetStatusDto GetStatus(int id);
    }
}
