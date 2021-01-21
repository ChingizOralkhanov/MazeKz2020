using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Repository;
using WebMaze.Services;

namespace WebMaze.DbStuff
{
    public static class SeedExtension
    {
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                AddIfNotExistRole(scope);
            }

            return host;
        }

        private static void AddIfNotExistRole(IServiceScope scope)
        {
            var roleRepository = scope.ServiceProvider.GetService<RoleRepository>();
            var listRole = new List<string>() { "Admin", "Policeman", "Doctor" };

            foreach (var roleName in listRole)
            {
                var roleFromDb = roleRepository.GetRoleByName(roleName);
                if (roleFromDb == null)
                {
                    var newRole = new Role() { Name = roleName };
                    roleRepository.Save(newRole);
                }
            }
        }
    }
}
