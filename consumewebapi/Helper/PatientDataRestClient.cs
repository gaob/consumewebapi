using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsumeWebAPI.Models;
using RestSharp;
using System.Net;

namespace ConsumeWebAPI.Helper
{
    public class PatientDataRestClient : IPatientDataRestClient
    {
        private readonly RestClient _client;
        private readonly string _url = "http://crudwithwebapi.azurewebsites.net/";

        public PatientDataRestClient()
        {
            _client = new RestClient(_url);
        }

        public IEnumerable<PatientDataModel> GetAll()
        {
            var request = new RestRequest("api/serverdata", Method.GET) { RequestFormat = DataFormat.Json };

            var response = _client.Execute<List<PatientDataModel>>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public void Add(PatientDataModel serverData)
        {
            var request = new RestRequest("api/serverdata", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(serverData);

            var response = _client.Execute<PatientDataModel>(request);

            if (response.StatusCode != HttpStatusCode.Created)
                throw new Exception(response.ErrorMessage);

        }
    }
}