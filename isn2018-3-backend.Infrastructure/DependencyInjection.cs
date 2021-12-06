using isn2018_3_backend.Domain.Interfaces;
using isn2018_3_backend.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IStatusRepository, StatusRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IPriorityRepository, PriorityRepository>();
            services.AddTransient<IFileRepository, FileRepository>();
            services.AddTransient<IUserProjectRepository, UserProjectRepository>();
            return services;
        }
    }
}
