using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsumeWebAPI.Models;

namespace ConsumeWebAPI.Helper
{
    public interface IPatientDataRestClient
    {
        void Add(PatientDataModel serverDataModel);
        IEnumerable<PatientDataModel> GetAll();
    }
}