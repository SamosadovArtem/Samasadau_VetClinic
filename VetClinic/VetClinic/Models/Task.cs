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
        public int petID { get; set; }
        public string petName { get; set; }
        public Task(int currentDoctor, string currentTaskTitle, string currentTaskText, int currentPetID, string currentPetName)
        {
            doctorID = currentDoctor;
            taskTitle = currentTaskTitle;
            taskText = currentTaskText;
            petID = currentPetID;
            petName = currentPetName;
        }
    }
}