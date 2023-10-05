using CreditWorks.VehicleManagement.Core.Managers;
using CreditWorks.VehicleManagement.Vehicles.Models;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Actions.Load
{
    public class LoadEffect : Effect<LoadAction>
    {
        private readonly ILogger<LoadEffect> _logger;
        private readonly VehicleManager _manager;
        private readonly NavigationManager _navigationManager;

        public LoadEffect(VehicleManager manager, ILogger<LoadEffect> logger, NavigationManager navigationManager)
        {
            _manager = manager;
            _logger = logger;
            _navigationManager = navigationManager;
        }

        public override async Task HandleAsync(LoadAction action, IDispatcher dispatcher)
        {
            try
            {
                //Technically we can run off the vehicle from the "already fetched" vehicle list
                //because the list has all the fields the editor needs.

                //however, in reality the lists could be fetching fewer/ other vehicle fields
                //OR
                //the vehicle editor needs to have access to fields that are not present in the list
                //OR
                //we might want to get fresh data in case someone has changed the vehicle details

                //therefore we have to make another DB call to fetch the correct fields/fresh data

                var result = await _manager.GetVehicle(Convert.ToInt32(action.Id));


                if (result != null)
                {
                    var vehicle = new Vehicle(result.Id.ToString(), result.Manufacturer.Id, result.Category.Id, result.Owner, result.Year, result.Weight);

                    _logger.LogInformation($"Loading vehicle");
                    dispatcher.Dispatch(new LoadSuccessAction(vehicle));
                }
                else
                {
                    //incase they deep link and vehicle does not exist
                    _navigationManager.NavigateTo("/vehicles", replace: true);
                    dispatcher.Dispatch(new ClearStateAction());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading vehicle, reason: {ex.Message}");
                dispatcher.Dispatch(new VehicleFailureAction());
            }
        }
    }
}
