using isn2018_3_backend.Domain.Dto.UserProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Domain.Interfaces
{
    public interface IUserProjectRepository
    {
        string AddUserProject(UserProjectDto userProject);
        List<UserProjectDto> GetAllUsersProject(int id);
        string DeleteserProject(UserProjectDto userProject);
    }
}
