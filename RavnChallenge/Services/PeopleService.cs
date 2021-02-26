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
        private GenderService _GenderService;
        private PlanetService _PlanetService;
        private VehicleService _VehicleService;
        public PeopleService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
            _GenderService = new GenderService(_HttpClient);
            _PlanetService = new PlanetService(_HttpClient);
            _VehicleService = new VehicleService(_HttpClient);
        }

        public async Task<List<People>> GetPeopleDetails(List<People> peopleList)
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

        public async Task<List<People>> GetPeople(int pageId)
        {
            try
            {
                string tagPageId = "?page=";
                var srtPageId = tagPageId + pageId;
                var peoplePaginator = await _HttpClient.GetJsonAsync<PeoplePaginator>($"api/people/{srtPageId}");
                return await this.GetPeopleDetails(peoplePaginator.PeopleList);
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
