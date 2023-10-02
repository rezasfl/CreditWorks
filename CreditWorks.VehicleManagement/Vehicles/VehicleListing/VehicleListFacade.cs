﻿using CreditWorks.VehicleManagement.Vehicles.VehicleListing.Actions.List;
using Fluxor;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing
{
    public class VehicleListFacade
    {
        private readonly ILogger<VehicleListFacade> _logger;
        private readonly IDispatcher _dispatcher;

        public VehicleListFacade(ILogger<VehicleListFacade> logger, IDispatcher dispatcher)
        {
            _logger = logger;
            _dispatcher = dispatcher;
        }

        internal void List()
        {
            _logger.LogInformation($"Dispatching action to load vehicles list");
            _dispatcher.Dispatch(new ListAction());
        }
    }
}