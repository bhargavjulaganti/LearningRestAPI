using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using QL.PersonalInfo.Interfaces;
using QL.Models;


namespace QL.Repository
{

    public class PersonalInfoRepository : IPersonalInfoRepository
    {

        private readonly IConfiguration configuration;
        private HttpClient client = new HttpClient();

        // private readonly IHttpClientFactory httpClientFactory ;


        public PersonalInfoRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<MyPersonalInfoModel> GetPersonalInfo(string testCaseName)
        {
            client.DefaultRequestHeaders.Add("x-api-key", configuration.GetSection("x-api-key-value").Get<string>());

            var uri = configuration.GetSection("url").Get<string>() + "/gettestdata?testcasename=" + testCaseName + "&Stage=beta";

            HttpResponseMessage response = await client.GetAsync(uri);

            string testdata = await response.Content.ReadAsStringAsync();

            var parsedObject = JObject.Parse(testdata);

            return new MyPersonalInfoModel()
            {

                LoanNumber = parsedObject.SelectToken("$.Item.LoanNumber").ToString(),
                UserName = parsedObject.SelectToken("$.Item.Username").ToString(),
                Password = parsedObject.SelectToken("$.Item.Password").ToString(),
                SSN = (long)parsedObject.SelectToken("$.Item.SSN")

            };



        }

    }
}