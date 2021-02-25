using ChallengeRavn.Helpers;
using ChallengeRavn.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChallengeRavn.Services
{
    public class PeopleService
    {
        private HttpClient _HttpClient;
        private ParseUrlHelper _ParseHelper;
        private GenderService _GenderService;
        private PlanetService _PlanetService;
        private VehicleService _VehicleService;
        public PeopleService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
            _ParseHelper = new ParseUrlHelper();
            _GenderService = new GenderService(_HttpClient);
            _PlanetService = new PlanetService(_HttpClient);
            _VehicleService = new VehicleService(_HttpClient);
        }
        public async Task<List<People>> GetPeople()
        {
            var peoplePaginator = await _HttpClient.GetJsonAsync<PeoplePaginator>("api/people/");
            var peopleListDetails = new List<People>();
            while (!string.IsNullOrEmpty(peoplePaginator.Next))
            {
                string pageId = _ParseHelper.GetPageIdFromURL(peoplePaginator.Next);
                peoplePaginator = await _HttpClient.GetJsonAsync<PeoplePaginator>($"api/people/{pageId}");
                peopleListDetails.AddRange(await this.GetPeopleDetails(peoplePaginator.PeopleList));
            }

            return peopleListDetails;
        }

        public async Task<IEnumerable<People>> GetPeopleDetails(IEnumerable<People> peopleList)
        {

            try
            {
                foreach (People people in peopleList)
                {
                    //get and update the gender in case is n/a
                    people.Gender = await _GenderService.GetGenderDetails(people);

                    //get and update the name of the planet
                    people.Planet = await _PlanetService.GetPlanetDetails(people);

                    //get and update the vehicles in case this people has
                    people.Vehicles = await _VehicleService.GetVehicleDetails(people);
                }
                return peopleList;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
