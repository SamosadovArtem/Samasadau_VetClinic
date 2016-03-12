using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VetClinic.Models.ViewModels
{
    public class DaysoffView
    {
        int ID { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> date { get; set; }

    }
}