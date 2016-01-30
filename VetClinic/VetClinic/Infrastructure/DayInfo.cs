using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetClinic.Infrastructure
{
    public class DayInfo
    {
        public int dayNumber;
        public bool isHaveTask;
        public string taskTitle;
        public string taskText;
        public int doctorID;
        public DayInfo(bool isUserTask, string userTaskTitle, string userTaskText, int userDayNumber, int userDoctor)
        {
            isHaveTask = isUserTask;
            taskTitle = userTaskTitle;
            taskText = userTaskText;
            dayNumber = userDayNumber;
            doctorID = userDoctor;
        }
        public DayInfo(int userDayNumber)
        {
            dayNumber = userDayNumber;
        }
    }
}