﻿namespace BusStation.Contracts
{
    using System.Collections.Generic;

    public interface IValidatorService
    {
        ICollection<string> ValidateModel(object model);
    }
}
