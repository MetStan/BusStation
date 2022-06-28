namespace BusStation.Controllers
{
    using BusStation.Contracts;
    using BusStation.ViewModels.Destinations;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Collections.Generic;
    using System.Linq;

    public class DestinationsController : Controller
    {
        private readonly IDestination service;

        public DestinationsController(IDestination destinationService)
        {
            service = destinationService;
        }

        [Authorize]
        public HttpResponse Add()
        {
            if (User.IsAuthenticated == false)
            {
                return Redirect("/Users/Login");
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(DestinationFormViewModel model)
        {
            if (User.IsAuthenticated == false)
            {
                return Redirect("/Users/Login");
            }

            List<string> errors = service.CreateDestination(model).ToList();

            if (errors.Any() == false)
            {
                return Redirect("/Destinations/All");
            }

            return View(model);
        }

        [Authorize]
        public HttpResponse All()
        {
            if (User.IsAuthenticated == false)
            {
                return Redirect("/Users/Login");
            }

            var destinations = service.GetAllDestinations();

            return View(destinations);
        }
    }
}
