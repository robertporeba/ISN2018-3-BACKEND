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
    public class PriorityRepository : IPriorityRepository
    {
        private readonly IsnContext _context;

        public PriorityRepository(IsnContext context)
        {
            _context = context;
        }
        public List<GetPriorityDto> GetAllPriorities()
        {
            var priorities = _context.Priorities.ToList();
            var prioritiesDtoList = new List<GetPriorityDto>();
            foreach (Priority priority in priorities)
            {
                var priorityDto = new GetPriorityDto
                {
                    Id = priority.Id,
                    Name = priority.Name,
                };
                prioritiesDtoList.Add(priorityDto);
            }

            return prioritiesDtoList;
        }

        public GetPriorityDto GetPriority(int id)
        {
            var priority = _context.Priorities.FirstOrDefault(a => a.Id == id);
            var priorityDto = new GetPriorityDto
            {
                Id = priority.Id,
                Name = priority.Name,
            };
            return priorityDto;
        }
    }
}
