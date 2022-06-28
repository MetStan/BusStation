namespace BusStation.ViewModels.Destinations
{
    using BusStation.Data.Models;
    using System.Collections;

    public class DestinationViewModel
    {
        public int DestinationId { get; init; }

        public string DestinationName { get; init; }

        public string Origin { get; init; }

        public string ImageUrl { get; init; }

        public string Date { get; init; }
        
        public string Time { get; init; }

        public int Tickets{ get; init; }
    }
}
