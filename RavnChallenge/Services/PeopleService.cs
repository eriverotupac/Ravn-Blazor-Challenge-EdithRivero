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
    //this class is for managing data of people
    public class PeopleService
    {
        private HttpClient _HttpClient;
        /*the following 3 classes are for fetching details of people.
         * Each of them return the corresponding detail as the name of the class implies.
         * It was necessary to add those classes because the value returned in the request contained a URLs, so
         * through those classes I made another request to get the final value.
         */
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

        /* Method name: GetPeople
         * Parameters: pageId {type: int}
         * Description: This method makes the call to the SWAPI. The pageId is necessary to identify 
         * what page will be queried.
         * Additional info: I decided to made requests using the number of pages because SWAPI returned people in
         * groups of ten. So, this method will request pageId=1, 2, 3... 9 to get the complete people.  
         */
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

        /* Method name: GetPeopleDetails
         * Parameters: peopleList {type: List of People}
         * Description: This method receives the list of people that the request has returned and 
         * updates the values with the corresponding data to all elements of the list.  
         */
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

                    //get and update the vehicles
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
