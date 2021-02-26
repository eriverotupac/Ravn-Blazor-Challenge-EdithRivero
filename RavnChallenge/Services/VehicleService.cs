using ChallengeRavn.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ChallengeRavn.Helpers;


namespace ChallengeRavn.Services
{
    //This class allows to get the data of vehicles
    public class VehicleService
    {
        private HttpClient _HttpClient;
        private ParseUrlHelper _ParseHelper;
        public VehicleService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
            _ParseHelper = new ParseUrlHelper();
        }

        /* Method name: GetVehicleDetails
        * Parameters: peopleDetails {type: People}
        * Description: This method receives an object people. Then, if the object people has vehicles, 
        * the method request all of them.
        */
        public async Task<string[]> GetVehicleDetails(People peopleDetails)
        {
            try
            {
                //get and update the vehicles in case this people has
                if (peopleDetails.Vehicles.Length > 0)
                {
                    int i = 0;
                    var vehicleNames = new string[peopleDetails.Vehicles.Length];
                    foreach (string vehicle in peopleDetails.Vehicles)
                    {
                        var vehicleId = _ParseHelper.GetIdFromURL(vehicle);
                        Vehicle vehicleDetails = await _HttpClient.GetJsonAsync<Vehicle>($"api/vehicles/{vehicleId}/");
                        vehicleNames[i] = vehicleDetails.Name;
                        i++;

                    }
                    return vehicleNames;
                }
                return peopleDetails.Vehicles;
            }
            catch (Exception)
            {
                return peopleDetails.Vehicles;
            }
        }
    }
}
