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
    //This class allows to get the data of planet
    public class PlanetService
    {
        private HttpClient _HttpClient;
        private ParseUrlHelper _ParseHelper;
        public PlanetService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
            _ParseHelper = new ParseUrlHelper();
        }

        /* Method name: GetPlanetDetails
         * Parameters: peopleDetails {type: People}
         * Description: This method receives an object people. Then, gets the id of the planet
         * through parsing the URL. Finally, obtains the planet name.  
         */
        public async Task<string> GetPlanetDetails(People peopleDetails)
        {
            try
            {
                var planetId = _ParseHelper.GetIdFromURL(peopleDetails.Planet);
                Planet planetDetails = await _HttpClient.GetJsonAsync<Planet>($"api/planets/{planetId}/");
                return planetDetails.Name;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
