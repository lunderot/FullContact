using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace FullContactApi
{
    interface IFullContactApi
    {
        Task<FullContactPerson> LookupPersonByEmailAsync(string email);
    }

    class API : IFullContactApi
    {

        private readonly string API_URL = "https://api.fullcontact.com";
        private readonly string PERSON_API_URL = "v2/person.json";
        private static string API_KEY;

        public API(string key)
        {
            API_KEY = key;
        }

        public async Task<FullContactPerson> LookupPersonByEmailAsync(string email)
        {
            var client = new RestClient(API_URL);
            var request = new RestRequest(PERSON_API_URL);
            request.AddParameter("email", email);
            request.AddHeader("X-FullContact-APIKey", API_KEY);
            IRestResponse<FullContactPerson> requestData = await client.ExecuteTaskAsync<FullContactPerson>(request);
            FullContactPerson returnData = null;
            if (requestData.IsSuccessful)
            {
                returnData = requestData.Data;
            }
            return returnData;
        }
    }
}
