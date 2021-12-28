using isn2018_3_backend.Domain.Dto.Column;
using isn2018_3_backend.Domain.Dto.Priority;
using isn2018_3_backend.Domain.Entity;
using isn2018_3_backend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Infrastructure.Repositories
{
    public class ColumnRepository : IColumnRepository
    {
        private readonly IsnContext _context;

        public ColumnRepository(IsnContext context)
        {
            _context = context;
        }
        public List<GetColumnDto> GetAllColumns(int id)
        {
            var columns = _context.Columns.Where(x => x.ProjectId == id).ToList();
            var columnsDtoList = new List<GetColumnDto>();
            foreach (Column column in columns)
            {
                var columnDto = new GetColumnDto
                {
                    Id = column.Id,
                    Name = column.Name,
                    ProjectId = column.ProjectId,
                };
                columnsDtoList.Add(columnDto);

            }
            return columnsDtoList;
        }

        public string AddColumn(AddColumnDto columnDto)
        {
            Column column = new Column
            {
                Name = columnDto.Name,
                ProjectId = columnDto.ProjectId
            };
            _context.Columns.Add(column);
            _context.SaveChanges();
            return "ok";
        }

        public string DeleteColumn(int id)
        {
            var column = _context.Columns.Find(id);
            if (column != null)
            {
                _context.Columns.Remove(column);
                _context.SaveChanges();
                return "ok";
            }

            return null;
        }
    }
}
