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
    public class PlanetService
    {
        private HttpClient _HttpClient;
        private ParseUrlHelper _ParseHelper;
        public PlanetService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
            _ParseHelper = new ParseUrlHelper();
        }
        public async Task<string> GetPlanetDetails(People peopleDetails)
        {
            try
            {
                //get and update the name of the planet
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
