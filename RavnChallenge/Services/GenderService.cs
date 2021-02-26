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
    //This class allows to get the type of gender
    public class GenderService
    {
        private HttpClient _HttpClient;
        private ParseUrlHelper _ParseHelper;
        public GenderService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
            _ParseHelper = new ParseUrlHelper();
        }

        /* Method name: GetGenderDetails
        * Parameters: peopleDetails {type: People}
        * Description: This method receives an object people. Then, if the gender is not a human, 
        * gets the id of the first specie through parsing the URL, and finally, obtains the specie name.
        * Additional info: The people type could have one or many species, but in the result view is only required one, 
        * so I decided to get the first specie.
        */
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
