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
        private readonly string _url = "http://ec2-54-149-114-200.us-west-2.compute.amazonaws.com:8080/IMHSystem/";
        string patient_id = "01";

        public PatientDataRestClient()
        {
            _client = new RestClient(_url);
            _client.AddHandler("application/json", new DynamicJsonDeserializer());
        }

        public IEnumerable<PatientDataModel> GetAll()
        {
            var request = new RestRequest("api/patient/requests/list/" + patient_id, Method.GET) { RequestFormat = DataFormat.Json };
            request.AddUrlSegment("start", "2015-04-17");

            var response = _client.Execute<dynamic>(request);

            dynamic data = response.Data;

            int totalNotifications = data.TotalNotifications;

            var notifications = data.Notifications;

            List<PatientDataModel> aList = new List<PatientDataModel>();

            foreach (var item in notifications)
            {
                aList.Add(new PatientDataModel((string)item.Id, (string)item.DoctorId, (string)item.Name, (string)item.Start, (string)item.End,
                                               (string)item.Type, (string)item.Time, (string)item.RecordID, (string)item.RecordName));
            }

            return aList;
        }

        public void Add(PatientDataModel theModel)
        {
            var request = new RestRequest("api/patient/requests/submit/" + patient_id, Method.POST) { RequestFormat = DataFormat.Json };

            request.AddParameter("DoctorID", theModel.DoctorID);
            request.AddParameter("Name", theModel.Name);
            request.AddParameter("Start", theModel.StartDate.ToShortDateString());
            request.AddParameter("End", theModel.EndDate.ToShortDateString());
            request.AddParameter("Type", theModel.Type);
            request.AddParameter("Time", theModel.Time.ToShortTimeString());
            request.AddParameter("RecordID", theModel.RecordID);
            request.AddParameter("RecordName", theModel.RecordName);

            var response = _client.Execute(request);

            if (response.StatusCode != HttpStatusCode.Created)
                throw new Exception(response.ErrorMessage);
        }

        public IEnumerable<PatientRecordModel> GetRecords()
        {
            string RecordID = "01";

            var request = new RestRequest("api/patient/records/list/" + patient_id + "/" + RecordID, Method.GET) { RequestFormat = DataFormat.Json };
            request.AddUrlSegment("start", "2015-04-10");
            request.AddUrlSegment("end", "2015-04-16");

            var response = _client.Execute<dynamic>(request);

            dynamic data = response.Data;

            int total = data.TotalRecords;

            var records = data.Records;

            List<PatientRecordModel> aList = new List<PatientRecordModel>();

            foreach (var item in records)
            {
                aList.Add(new PatientRecordModel((string)item.Id, (string)item.Date, (string)item.Time, (int)item.Value));
            }

            return aList;
        }
    }
}
