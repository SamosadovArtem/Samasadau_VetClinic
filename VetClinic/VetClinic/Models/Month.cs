using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VetClinic.Models
{
    public class Month
    {

        private DateTime currentMonth;

        private IRepository repository;
        public List<Day> days { get; }
        public int daysInMonth { get; }
        public int fristDayOfMonthNumber { get; }
        public int lastDayOfMonthNumber { get; }
        public int GetTodayNumber
        {
            get
            {
                return DateTime.Today.Day;
            }
        }

        public Month()
        {
            repository = DependencyResolver.Current.GetService<IRepository>();
            fristDayOfMonthNumber = GetDayOfMonthNumber(DateTime.Today);
            daysInMonth = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            days = new List<Day>();
        }
        private static int GetDayOfMonthNumber(DateTime userDate)
        {
            //TODO
            DateTime today = userDate;
            //DateTime today = DateTime.Today;
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
                    string petName = GetPetNameByID(allSchedule[i].Pet);
                    Task tempTask = new Task(allSchedule[i].Doctor, allSchedule[i].Title, allSchedule[i].Text,allSchedule[i].Pet, petName, allSchedule[i].Time);
                    taskList.Add(tempTask);
                }
            }
            return taskList;
        }
        private string GetPetNameByID(int petID)
        {
            string petName = repository.GetPetNameByID(petID);
            return petName;
        }
    }

}