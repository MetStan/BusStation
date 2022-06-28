namespace BusStation.Services
{
    using BusStation.Contracts;
    using BusStation.Data;
    using BusStation.Data.Common;
    using BusStation.Data.Models;
    using BusStation.ViewModels.Destinations;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DestinationService : IDestination
    {
        private readonly IValidatorService validator;
        private readonly BusStationDbContext db;

        //public DestinationService(IRepository data,
        //    IDestination destination,
        //    IValidatorService validatorService)

        //{
        //    db = data;
        //    service = destination;
        //    validator = validatorService;
        //}

        public DestinationService(
            IValidatorService validator,
            BusStationDbContext db)
        {
            this.validator = validator;
            this.db = db;
        }

        public ICollection<string> CreateDestination(DestinationFormViewModel model)
        {
            List<string> errors = validator.ValidateModel(model).ToList();

            if (errors.Any())
            {
                return errors;
            }

            var IsValidDateTime = DateTime.TryParse(model.Date, out DateTime validDate);
            string date;
            string time;
            if (IsValidDateTime && validDate >= DateTime.Now)
            {
                var result = validDate.ToString();
                string[] elements = result.Split(" г. ", StringSplitOptions.RemoveEmptyEntries);
                date = elements[0];
                time = elements[1];
            }
            else
            {
                return errors;
            }
            
            var newDestination = new Destination
            {
                DestinationName = model.DestinationName,
                Origin = model.Origin,
                ImageUrl = model.ImageUrl,
                Date = date,
                Time = time,
            };

            db.Destinations.Add(newDestination);
            db.SaveChanges();

            return errors;
        }

        public ICollection<DestinationViewModel> GetAllDestinations()
        {
            var trips = db.Destinations
                 .Select(t => new DestinationViewModel()
                 {
                     DestinationId = t.Id,
                     DestinationName = t.DestinationName,
                     Origin = t.Origin,
                     ImageUrl = t.ImageUrl,
                     Date = t.Date,
                     Time = t.Time,
                     Tickets = t.Tickets.Where(t => t.UserId == null).Count(),
                 })
                 .ToList();

            return trips;
        }
    }
}
