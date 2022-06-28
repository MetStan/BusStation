namespace BusStation.Contracts
{
    using BusStation.ViewModels.Destinations;
    using System.Collections.Generic;

    public interface IDestination
    {
        ICollection<string> CreateDestination(DestinationFormViewModel model);

        ICollection<DestinationViewModel> GetAllDestinations();
    }
}
