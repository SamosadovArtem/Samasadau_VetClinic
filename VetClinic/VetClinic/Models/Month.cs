using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetClinic.Models
{
    public class Month
    {

        public List<Day> days { get; }
        public int daysInMonth { get; }
        public int fristDayOfMonthNumber { get; }
        public int GetTodayNumber
        {
            get
            {
                return DateTime.Today.Day;
            }
        }

        public Month()
        {
            fristDayOfMonthNumber = GetFirstDayOfMonthNumber();
            daysInMonth = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            days = new List<Day>();
        }
        private static int GetFirstDayOfMonthNumber()
        {
            DateTime today = DateTime.Today;
            int daysFromFirstDay = today.Day - 1;
            DateTime firstDayOfMonth = today.AddDays(-daysFromFirstDay);

            string firstDayOfMonthName = firstDayOfMonth.DayOfWeek.ToString();

            int firstDayOfMonthNumber = -1;
            switch (firstDayOfMonthName)
            {
                case "Monday":
                    firstDayOfMonthNumber = 0;
                    break;
                case "Tuesday":
                    firstDayOfMonthNumber = 1;
                    break;
                case "Wednesday":
                    firstDayOfMonthNumber = 2;
                    break;
                case "Thursday":
                    firstDayOfMonthNumber = 3;
                    break;
                case "Friday":
                    firstDayOfMonthNumber = 4;
                    break;
                case "Saturday":
                    firstDayOfMonthNumber = 5;
                    break;
                case "Sunday":
                    firstDayOfMonthNumber = 6;
                    break;
            }

            return firstDayOfMonthNumber;
        }
        public void GenerateDaysInfo(List<Schedule> allSchedule)
        {
            for (int i = 0; i < daysInMonth; i++)
            {
                int counterForSchedule = 0;
                DateTime today = DateTime.Today;
                int daysFromFirstDay = today.Day - 1;
                DateTime currentDay = today.AddDays(-daysFromFirstDay + i);
                Day tempDayInfo;
                List<Task> tasksForCurrentDay = TaskToDate(allSchedule, currentDay);
                if (tasksForCurrentDay.Count != 0)
                {
                    tempDayInfo = new Day(i + 1, tasksForCurrentDay, true);

                    counterForSchedule++;
                }
                else
                {
                    tempDayInfo = new Day(i + 1);
                }
                days.Add(tempDayInfo);
            }
        }

        private List<Task> TaskToDate(List<Schedule> allSchedule, DateTime currentDate)
        { //TODO: Через запрос доставать нужные даты, наверное
            List<Task> taskList = new List<Task>();
            for (int i = 0; i < allSchedule.Count; i++)
            {
                if (currentDate == allSchedule[i].Date)
                {
                    Task tempTask = new Task(allSchedule[i].Doctor, allSchedule[i].Title, allSchedule[i].Text);
                    taskList.Add(tempTask);
                }
            }
            return taskList;
        }
    }
}