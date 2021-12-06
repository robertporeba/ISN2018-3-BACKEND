using isn2018_3_backend.Domain.Dto.Project;
using isn2018_3_backend.Domain.Entity;
using isn2018_3_backend.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
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
        private IHttpContextAccessor _httpContextAccessor { get; }

        public ProjectRepository(IsnContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        public string AddProject(AddProjectDto projectDto)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var date = DateTime.Now;
            var project = new Project
            {
                Name = projectDto.Name,
                Author = projectDto.Author,
                CreateDate = date
            };
            _context.Projects.Add(project);
            _context.SaveChanges();

            var projectId = _context.Projects.FirstOrDefault(x => x.CreateDate == date).Id;
            var userProject = new UserProject
            {
                UserName = userName,
                ProjectId = projectId,
            };
            _context.UserProjects.Add(userProject);
            _context.SaveChanges();
            return "ok";
        }

        public string DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);
            var userProjects = _context.UserProjects.Where(x => x.ProjectId == id).AsQueryable();
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
                _context.UserProjects.RemoveRange(userProjects);
                _context.SaveChanges();
                return "ok";
            }
            
            return null;
        }

        public List<GetProjectDto> GetAllProjects()
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var userProjects = _context.UserProjects.Where(x => x.UserName == userName).AsQueryable();
            var projects = _context.Projects.Where(x=> userProjects.Any(s=> s.ProjectId == x.Id)).ToList();
            var projectsDtoList = new List<GetProjectDto>();
            foreach (Project project in projects)
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
