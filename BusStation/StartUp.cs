namespace BusStation
{
    using MyWebServer;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Microsoft.EntityFrameworkCore;
    using BusStation.Data;
    using BusStation.Contracts;
    using BusStation.Services;
    using BusStation.Data.Common;

    public class Startup
    {
        public static async Task Main()
           => await HttpServer
               .WithRoutes(routes => routes
                   .MapStaticFiles()
                   .MapControllers())
               .WithServices(services => services
               .Add<BusStationDbContext>()
               .Add<IValidatorService, ValidatorService>()
               .Add<IRepository, Repository>()
               .Add<IPasswordHasher, PasswordHasher>()
               .Add<IUserService, UserService>()
               .Add<IDestination, DestinationService>()
               .Add<ITicketService, TicketService>()
               .Add<IViewEngine, CompilationViewEngine>())
               //.WithConfiguration<BusStationDbContext>(context => context
               //    .Database.Migrate())
               .Start();
    }
}
