using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetClinic.Models
{
    public class Task
    {
        public int doctorID { get; set; }
        public string taskTitle { get; set; }
        public string taskText { get; set; }
        public Task(int currentDoctor, string currentTaskTitle, string currentTaskText)
        {
            doctorID = currentDoctor;
            taskTitle = currentTaskTitle;
            taskText = currentTaskText;
        }
    }
}