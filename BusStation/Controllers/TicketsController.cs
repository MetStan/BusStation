namespace BusStation.Controllers
{
    using BusStation.Contracts;
    using BusStation.ViewModels.Tickets;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TicketsController : Controller
    {
        private readonly ITicketService tickets;

        public TicketsController(ITicketService ticketService)
        {
            this.tickets = ticketService;
        }

        [Authorize]
        public HttpResponse Create(int destinationId)
        {
            return View(new TicketFormViewModel
            {
                DestinationId = destinationId,
                UserId = User.Id
            });
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(TicketFormViewModel model, int destinationId)
        {
            List<string> errors = tickets.CreateSeat(model, destinationId).ToList();

            if (errors.Any())
            {
                return View(model);
            }

            return Redirect("/Destinations/All");
        }

        public HttpResponse Reserve(int destinationId)
        {
            if (User.IsAuthenticated == false)
            {
                return Redirect("/Users/Login");
            }

            var bookedTrip = tickets.BookTrip(User.Id, destinationId);

            return Redirect("/Destinations/All");
        }
        

        [Authorize]
        public HttpResponse MyTickets()
        {
            var myTickets = tickets.GetAllTickets(User.Id);

            return View(myTickets);
        }
    }
}
