using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsumeWebAPI.Models;
using RestSharp;
using System.Net;
using RestSharp.Deserializers;

namespace ConsumeWebAPI.Helper
{
    public class PatientDataRestClient : IPatientDataRestClient
    {
        private readonly RestClient _client;
        private readonly string _url = "http://crudwithwebapi.azurewebsites.net/";

        public PatientDataRestClient()
        {
            _client = new RestClient(_url);
            _client.AddHandler("application/json", new DynamicJsonDeserializer());
        }

        public IEnumerable<PatientDataModel> GetAll()
        {
            string patient_id = "20000001";

            var request = new RestRequest("api/patient/requests/" + patient_id, Method.GET) { RequestFormat = DataFormat.Json };
            request.AddUrlSegment("start", "2015-04-17");

            var response = _client.Execute<dynamic>(request);

            dynamic data = response.Data;

            int totalNotifications = data.totalNotifications;

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public void Add(PatientDataModel serverData)
        {
            var request = new RestRequest("api/serverdata", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(serverData);

            /*
            var response = _client.Execute<PatientDataModel>(request);

            if (response.StatusCode != HttpStatusCode.Created)
                throw new Exception(response.ErrorMessage);
            */
        }
    }
}