using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ConsumeWebAPI.Models
{
    public class PatientDataModel
    {
        public string Id { get; set; }

        [Display(Name = "Doctor ID")]
        public string DoctorID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; }

        [Display(Name = "Record ID")]
        public string RecordID { get; set; }

        [Display(Name = "Record Name")]
        public string RecordName { get; set; }

        public PatientDataModel(string id, string d_id, string name, string start, string end, string type, string time, string r_id, string r_name)
        {
            Id = id;
            DoctorID = d_id;
            Name = name;
            StartDate = DateTime.ParseExact(start, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            EndDate = DateTime.ParseExact(start, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Type = type;
            Time = DateTime.Parse(time);
            RecordID = r_id;
            RecordName = r_name;
        }

        public PatientDataModel()
        {

        }
    }
}
