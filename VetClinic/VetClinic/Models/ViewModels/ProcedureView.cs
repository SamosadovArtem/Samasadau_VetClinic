using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetClinic.Models.ViewModels
{
    public class ProcedureView
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Cost { get; set; }
    }
}