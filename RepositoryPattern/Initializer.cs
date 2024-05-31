using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern.Repositories;
using RepositoryPattern.Repositories.Abstraction;

namespace RepositoryPattern
{
    public static class Initializer
    {
        /*
         * ################################ README ###############################
         *
         * ########## For first use ##########
         * 1. Set path in CustomDbContext (for SQLite)> OnConfiguration where you want to create db (prefer path to project as : C\\path\\to\\project\\databaseFile.db)
         * 2. Add a reference to this project
         * 3. Call AddDbLayer in ServiceBuilder
         * 4. Install Microsoft.EntityFrameworkCore.Design in the executable project.
         * 5. Open the package manager console ( Tools > NuGet Package Manager > Package Manager Console ).
         * 6. Set the default project for this project
         * 7. Enter the "add-migration Init" command in the console.
         * 8. Enter the "update-database" command in the console.
         *
         * ########## How to create a table in a database ##########
         *
         * 1. Create a Model
         * 2. Create a Dto
         * 3. Create QueryBuilder
         * 4.1 Create a repository with an interface
         * 4.2 Create overriding functions for MapToModel and MapToDto methods 
         * 5. Add DbSet to CustomDbContext
         * 6. Register the repository as Scoped in the AddRepositories method
         *
         * (See the structure with Dummy)
         * 
         */

        public static IServiceCollection AddDbLayer(this IServiceCollection services)
        {
            services.AddDbContext<CustomDbContext>();
            services.AddRepositories();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDummyRepository, DummyRepository>();
            return services;
        }
    }
}
