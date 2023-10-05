﻿using CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Actions;
using CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Actions.Load;
using Fluxor;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleEditing
{
    public class VehicleFacade
    {
        private readonly ILogger<VehicleFacade> _logger;
        private readonly IDispatcher _dispatcher;
        private readonly IState<VehicleState> _state;

        public VehicleFacade(ILogger<VehicleFacade> logger, IDispatcher dispatcher, IState<VehicleState> state)
        {
            _logger = logger;
            _dispatcher = dispatcher;
            _state = state;
        }

        internal void ClearState()
        {
            _dispatcher.Dispatch(new ClearStateAction());
        }

        internal void Create()
        {
            throw new NotImplementedException();
        }

        internal void Load(string id)
        {
            _logger.LogInformation($"Dispatching action to load vehicle");
            _dispatcher.Dispatch(new LoadAction(id));
        }

        internal void SetOwner(string? owner)
        {
            if (_state.Value.UnderEdit != null)
            {
                _logger.LogInformation($"Setting vehicle's owner");

                var categories = _state.Value.UnderEdit.SetOwner(owner);

                _dispatcher.Dispatch(new VehicleSuccessAction(categories));
            }
            else
            {
                var errorMessage = $"No vehicle under edit";
                _logger.LogError($"Error setting vehicle's owner, reason: {errorMessage}");
                _dispatcher.Dispatch(new VehicleFailureAction());
            }
        }

        internal void SetManufacturer(int? manufacturer)
        {
            if (_state.Value.UnderEdit != null)
            {
                _logger.LogInformation($"Setting vehicle's manufacturer");

                var categories = _state.Value.UnderEdit.SetManufacturer(manufacturer);

                _dispatcher.Dispatch(new VehicleSuccessAction(categories));
            }
            else
            {
                var errorMessage = $"No vehicle under edit";
                _logger.LogError($"Error setting vehicle's manufacturer, reason: {errorMessage}");
                _dispatcher.Dispatch(new VehicleFailureAction());
            }
        }

        internal void SetYear(int? year)
        {
            if (_state.Value.UnderEdit != null)
            {
                _logger.LogInformation($"Setting vehicle's year");

                var categories = _state.Value.UnderEdit.SetYear(year);

                _dispatcher.Dispatch(new VehicleSuccessAction(categories));
            }
            else
            {
                var errorMessage = $"No vehicle under edit";
                _logger.LogError($"Error setting vehicle's year, reason: {errorMessage}");
                _dispatcher.Dispatch(new VehicleFailureAction());
            }
        }

        internal void SetWeight(float? weight)
        {
            if (_state.Value.UnderEdit != null)
            {
                _logger.LogInformation($"Setting vehicle's weight");

                var categories = _state.Value.UnderEdit.SetWeight(weight);

                _dispatcher.Dispatch(new VehicleSuccessAction(categories));
            }
            else
            {
                var errorMessage = $"No vehicle under edit";
                _logger.LogError($"Error setting vehicle's weight, reason: {errorMessage}");
                _dispatcher.Dispatch(new VehicleFailureAction());
            }
        }
    }
}