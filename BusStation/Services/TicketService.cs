namespace BusStation.Services
{
    using BusStation.Contracts;
    using BusStation.Data;
    using BusStation.Data.Models;
    using BusStation.ViewModels.Tickets;
    using System.Collections.Generic;
    using System.Linq;

    public class TicketService : ITicketService
    {
        private readonly IValidatorService validator;
        private readonly BusStationDbContext db;

        public TicketService(IValidatorService validator, 
                                BusStationDbContext db)
        {
            this.validator = validator;
            this.db = db;
        }

        public bool BookTrip(string userId, int destinationId)
        {
            var ticket = db.Tickets
                        .Where(u => u.UserId == null
                               && u.DestinationId == destinationId)
                        .FirstOrDefault();

            if (ticket == null)
            {
                return false;
            }

            var user = db.Users
                         .Find(userId);

            ticket.User = user;
            db.Tickets.Update(ticket);
            db.SaveChanges();

            return true;
        }

        public ICollection<string> CreateSeat(TicketFormViewModel model, int destinationId)
        {
            List<string> errors = validator.ValidateModel(model).ToList();

            if (errors.Any())
            {
                return errors;
            }

            var isValidPrice = decimal.TryParse(model.Price, out var price);

            if (isValidPrice == false)
            {
                errors.Add("Input valid price!");
                return errors;
            }

            for (int i = 0; i < model.TicketsCount; i++)
            {
                var ticket = new Ticket
                {
                    Price = price,
                    DestinationId = destinationId,
                };

                db.Tickets.Add(ticket);
            }

            db.SaveChanges();
            return errors;
        }

        public ICollection<DestinationTicketsViewModel> GetAllTickets(string userId)
        {
            var tickets = db.Tickets
               .Where(t => t.UserId == userId)
               .OrderByDescending(t => t.Destination.DestinationName)
               .Select(dt => new DestinationTicketsViewModel
               {
                   ImageUrl = dt.Destination.ImageUrl,
                   Destination = $"From {dt.Destination.Origin} to {dt.Destination.DestinationName}",
                   DepartureDate = $"Date: {dt.Destination.Date}, Hour:{dt.Destination.Time}",
                   Price = dt.Price.ToString(),
               })
               .ToList();

            return tickets;
        }
    }
}
