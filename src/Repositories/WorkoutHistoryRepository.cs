using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using QL.PersonalInfo.Interfaces;
using QL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace QL.Repository
{

    public class WorkoutHistoryRepository : IWorkoutHistoryRepository
    {

        private readonly IConfiguration configuration;
        private HttpClient client = new HttpClient();

        // private readonly IHttpClientFactory httpClientFactory ;


        public WorkoutHistoryRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<List<WorkoutHistoryModel>> GetWorkoutHistory(string WorkoutType)
        {

            var uri = "https://q6rrg5mw2k.execute-api.us-east-2.amazonaws.com/default/getdata?workOutType=" + WorkoutType;

            HttpResponseMessage response = await client.GetAsync(uri);

            string testdata = await response.Content.ReadAsStringAsync();

            dynamic data = JsonConvert.DeserializeObject(testdata);

            var mydata = data.Items[0].CreatedDate;

            var myresponse = new List<WorkoutHistoryModel>();

            foreach(var p in data.Items)
            {
                myresponse.Add(new WorkoutHistoryModel()
                    {
                        CreatedDate  = p.CreatedDate,
                        Set1 = p.Set1,
                        Set2 = p.Set2,
                        Set3 = p.Set3,
                        Set4 = p.Set4
                    }
                ); 
            }

            return myresponse;
        }

    }
}