﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ConsumeWebAPI.Models
{
    public class PatientRecordModel
    {
        public string Id { get; set; }
        public DateTime Time { get; set; }
        public int value { get; set; }

        public PatientRecordModel(string id, string date, string time, int the_value)
        {
            Id = id;
            Time = DateTime.ParseExact(date + " " + time, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture); ;
            value = the_value;
        }

        public PatientRecordModel()
        {

        }
    }
}
