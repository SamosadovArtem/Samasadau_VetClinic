﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetClinic.Models.ViewModels
{
    public class RecallView
    {
        public int DoctorID { get; set; }
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}