using SimpleInjector;
using SimpleInjector.Packaging;
using CorporateChatClub.Infrastructure.Data;
using CorporateChatClub.Infrastructure.Interfaces;
using CorporateChatClub.Infrastructure.Repositories.Dapper;
using CorporateChatClub.Service.Interfaces;
using CorporateChatClub.Service.Services;

namespace CorporateChatClub
{
    public class RegisterServices : IPackage
    {
        void IPackage.RegisterServices(Container container)
        {
            container.Register<DbContext>();
            container.Register<IUserRepository, UserRepository>();
            container.Register<IUserService, UserService>();

        }
    }
}


