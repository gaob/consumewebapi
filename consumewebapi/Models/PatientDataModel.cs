using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ConsumeWebAPI.Models
{
    public class PatientDataModel
    {
        public int Id { get; set; }

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
    }
}