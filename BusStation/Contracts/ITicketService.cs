namespace BusStation.Contracts
{
    using BusStation.ViewModels.Tickets;
    using System.Collections.Generic;

    public interface ITicketService
    {
        ICollection<string> CreateSeat(TicketFormViewModel model, int destinationId);

        ICollection<DestinationTicketsViewModel> GetAllTickets(string userId);

        bool BookTrip(string userId, int destinationId);
    }
}
