using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetClinic.Models
{
    public class Day
    {
        public List<Task> taskList { get;  }
        public bool isHaveTask { get; }
        public int dayNumber { get; }

        public Day(int currentDayNumber)
        {
            dayNumber = currentDayNumber;
        }
        public Day(int currentDayNumber, List<Task> currentTask, bool current_isHaveTask)
        {
            dayNumber = currentDayNumber;
            taskList = currentTask;
            isHaveTask = current_isHaveTask;
        }
    }
}