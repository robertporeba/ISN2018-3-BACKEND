using isn2018_3_backend.Domain.Dto.Project;
using isn2018_3_backend.Domain.Entity;
using isn2018_3_backend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IsnContext _context;

        public ProjectRepository(IsnContext context)
        {
            _context = context;
        }
        public string AddProject(AddProjectDto projectDto)
        {
            var project = new Project
            {
                Name = projectDto.Name,
                Author = projectDto.Author,
                CreateDate = DateTime.Now
            };
            _context.Projects.Add(project);
            _context.SaveChanges();
            return "ok";
        }

        public string DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
                return "ok";
            }
            return null;
        }

        public List<GetProjectDto> GetAllProjects()
        {
            var projects = _context.Projects.ToList();
            var projectsDtoList = new List<GetProjectDto>();
            foreach(Project project in projects)
            {
                var projectDto = new GetProjectDto
                {
                    Id = project.Id,
                    Name = project.Name,
                    Author = project.Author,
                    CreateDate = project.CreateDate
                };
                projectsDtoList.Add(projectDto);
            }
            
            return projectsDtoList;
        }

        public GetProjectDto GetProject(int id)
        {
            var project = _context.Projects.FirstOrDefault(a => a.Id == id);
            var projectDto = new GetProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Author = project.Author,
                CreateDate = project.CreateDate
            };
            return projectDto;
        }
    }
}
