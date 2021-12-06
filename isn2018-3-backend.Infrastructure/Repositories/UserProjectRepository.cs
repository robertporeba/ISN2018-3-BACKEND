using isn2018_3_backend.Domain.Dto.UserProject;
using isn2018_3_backend.Domain.Entity;
using isn2018_3_backend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Infrastructure.Repositories
{
    public class UserProjectRepository : IUserProjectRepository
    { 
        private readonly IsnContext _context;

        public UserProjectRepository(IsnContext context)
        {
            _context = context;
        }

        public string AddUserProject(UserProjectDto userProject)
        {
            var userProjectToSave = new UserProject
            {
                UserName = userProject.UserName,
                ProjectId = userProject.ProjectId,
            };
            _context.UserProjects.Add(userProjectToSave);
            _context.SaveChanges();
            return "ok";
        }

        public string DeleteserProject(UserProjectDto usersProject)
        {
            var userProject = _context.UserProjects.FirstOrDefault(x => x.ProjectId == usersProject.ProjectId && x.UserName == usersProject.UserName);
            if (userProject != null)
            {
                _context.UserProjects.Remove(userProject);
                _context.SaveChanges();
                return "ok";
            }

            return null;
        }

        public List<UserProjectDto> GetAllUsersProject(int id) 
        { 
            var userProjects = _context.UserProjects.Where(x=> x.ProjectId == id).ToList();
            var userProjectsDtoList = new List<UserProjectDto>();
            foreach (UserProject userProject in userProjects)
            {
                var userProjectDto = new UserProjectDto
                {
                    UserName = userProject.UserName,
                    ProjectId = userProject.ProjectId,
                };
                userProjectsDtoList.Add(userProjectDto);

            }

            return userProjectsDtoList;
        }
    }
}
