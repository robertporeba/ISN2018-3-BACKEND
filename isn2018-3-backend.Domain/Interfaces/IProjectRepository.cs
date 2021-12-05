using isn2018_3_backend.Domain.Dto.Project;
using isn2018_3_backend.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Domain.Interfaces
{
    public interface IProjectRepository
    {
        string AddProject(AddProjectDto project);
        string DeleteProject(int id);
        GetProjectDto GetProject(int id);
        List<GetProjectDto> GetAllProjects();
    }
}
