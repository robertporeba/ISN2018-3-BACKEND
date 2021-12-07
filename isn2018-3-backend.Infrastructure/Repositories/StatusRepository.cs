using isn2018_3_backend.Domain.Dto.Status;
using isn2018_3_backend.Domain.Entity;
using isn2018_3_backend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Infrastructure.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly IsnContext _context;

        public StatusRepository(IsnContext context)
        {
            _context = context;
        }
        public List<GetStatusDto> GetStatuses()
        {
            var statuses = _context.Statuses.ToList();
            var statusesDtoList = new List<GetStatusDto>();
            foreach (Status status in statuses)
            {
                var statusDto = new GetStatusDto
                {
                    Id = status.Id,
                    Name = status.Name,
                };
                statusesDtoList.Add(statusDto);
            }

            return statusesDtoList;
        }

        public List<GetStatusDto> GetAllStatuses()
        {
            var statuses = _context.Statuses.ToList();
            var statusesDtoList = new List<GetStatusDto>();
            foreach (Status status in statuses)
            {
                var statusDto = new GetStatusDto
                {
                    Id = status.Id,
                    Name = status.Name,
                };
                statusesDtoList.Add(statusDto);
            }

            return statusesDtoList;
        }

        public GetStatusDto GetStatus(int id)
        {
            var status = _context.Statuses.FirstOrDefault(a => a.Id == id);
            var statusDto = new GetStatusDto
            {
                Id = status.Id,
                Name = status.Name,
            };
            return statusDto;
        }
    }
}
