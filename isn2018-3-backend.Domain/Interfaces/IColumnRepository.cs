using isn2018_3_backend.Domain.Dto.Column;
using isn2018_3_backend.Domain.Dto.Priority;
using isn2018_3_backend.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Domain.Interfaces
{
    public interface IColumnRepository
    {
        List<GetColumnDto> GetAllColumns(int id);
        string AddColumn(AddColumnDto column);
        string DeleteColumn(int id);
    }
}
