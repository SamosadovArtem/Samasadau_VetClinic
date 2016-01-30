using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetClinic.Models;

namespace VetClinic.Infrastructure
{
    public class DateWork
    {

        public DateWork()
        {
            FristDayOfMonthNumber = GetFirstDayOfMonthNumber();
            DaysInMonth = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            daysInfo = new List<DayInfo>();
        }
        private static int GetFirstDayOfMonthNumber()
        {
            DateTime today = DateTime.Today;
            int daysFromFirstDay = today.Day - 1;
            DateTime firstDayOfMonth = today.AddDays(-daysFromFirstDay);

            string firstDayOfMonthName = firstDayOfMonth.DayOfWeek.ToString();

            int firstDayOfMonthNumber =  -1;
            switch (firstDayOfMonthName)
            {
                case "Monday": firstDayOfMonthNumber = 0;
            break;
                case "Tuesday": firstDayOfMonthNumber = 1;
                    break;
                case "Wednesday": firstDayOfMonthNumber = 2;
                    break;
                case "Thursday": firstDayOfMonthNumber = 3;
                    break;
                case "Friday": firstDayOfMonthNumber = 4;
                    break;
                case "Saturday":firstDayOfMonthNumber = 5;
                    break;
                case "Sunday":firstDayOfMonthNumber = 6;
                    break;
             }

            return firstDayOfMonthNumber;
        }
        public int FristDayOfMonthNumber
        {
            get;
        }
        public int DaysInMonth
        {
            get;
        }
        public int GetTodayNumber
        {
            get
            {
                return DateTime.Today.Day;
            }
        }
        public List<DayInfo> daysInfo { get; }

        public List<DayInfo> GenerateDaysInfo(List<Schedule> allSchedule)
        {
            
            for (int i = 0;i<DaysInMonth;i++)
            {
                int counterForSchedule = 0;
                DateTime today = DateTime.Today;
                int daysFromFirstDay = today.Day - 1;
                DateTime currentDay = today.AddDays(-daysFromFirstDay+i);
                DayInfo tempDayInfo;
                if (IsHaveTaskToDate(allSchedule, currentDay))
                {
                    tempDayInfo = new DayInfo(true, allSchedule[counterForSchedule].Title, 
                        allSchedule[counterForSchedule].Text, i + 1,allSchedule[counterForSchedule].Doctor);

                    counterForSchedule++;
                }
                else
                {
                    tempDayInfo = new DayInfo(i + 1);
                }
                daysInfo.Add(tempDayInfo);
            }
            return daysInfo;
        }
        private bool IsHaveTaskToDate(List<Schedule> allScedule, DateTime currentDate)
        {
            for (int i = 0; i < allScedule.Count; i++)
            {
                if (currentDate == allScedule[i].Date)
                {
                    return true;
                }
            }
            return false;
        }
        

    }
}