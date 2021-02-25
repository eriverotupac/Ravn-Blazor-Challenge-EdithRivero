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
        public async Task<IEnumerable<People>> GetPeople()
        {
            var peoplePaginator = await _HttpClient.GetJsonAsync<PeoplePaginator>($"api/people/");
            var count = peoplePaginator.Count;
            var peopleList = await this.GetPeopleDetails(peoplePaginator.PeopleList);
            return peopleList;
        }
        public async Task<IEnumerable<People>> GetPeopleDetails(IEnumerable<People> peopleList)
        {
            var peopleListDetails = new List<People>();
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

                    //add people with details to list
                    peopleListDetails.Add(people);
                }
                return peopleListDetails; 
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
