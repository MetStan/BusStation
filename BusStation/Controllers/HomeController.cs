namespace BusStation.Controllers
{
    using MyWebServer.Http;
    using MyWebServer.Controllers;
    using BusStation.Contracts;

    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            
            if (User.IsAuthenticated)
            {
                return Redirect("/Destinations/All");
            }

            return this.View();
        }
    }
}
