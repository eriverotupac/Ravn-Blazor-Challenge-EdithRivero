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
    public class GenderService
    {
        private HttpClient _HttpClient;
        private ParseUrlHelper _ParseHelper;
        public GenderService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
            _ParseHelper = new ParseUrlHelper();
        }
        public async Task<string> GetGenderDetails(People peopleDetails)
        {
            try
            {
                //get and update the gender if is not human
                if (peopleDetails.Gender.Equals(DomainValues.GenderValues.None))
                {
                    var specieId = _ParseHelper.GetIdFromURL(peopleDetails.Species[0]);
                    Specie specieDetails = await _HttpClient.GetJsonAsync<Specie>($"api/species/{specieId}/");
                    return specieDetails.Name;
                }
                else
                {
                    return DomainValues.GenderValues.Human;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }

        }
    }
}
