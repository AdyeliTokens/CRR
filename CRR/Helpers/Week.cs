﻿using CRR.Models.Vistas.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace CRR.Helpers
{
    public class Week
    {
        public static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            // Use first Thursday in January to get first week of the year as
            // it will never be in Week 52/53
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            // As we're adding days to a date in Week 1,
            // we need to subtract 1 in order to get the right date for week #1
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            // Using the first Thursday as starting week ensures that we are starting in the right year
            // then we add number of weeks multiplied with days
            var result = firstThursday.AddDays(weekNum * 7);

            // Subtract 3 days from Thursday to get Monday, which is the first weekday in ISO8601
            return result.AddDays(-3);
        }

        public static List<DaysOfWeek> getDaysofWeek(int weekNo)
        {
            List<DaysOfWeek> daysOfWeek = new List<DaysOfWeek>();
            string[] listDay = new string[] { "Monday", "Thuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            DateTime FirstDay = FirstDateOfWeekISO8601(DateTime.Now.Year, weekNo);

            foreach(var day in listDay)
            {
                DaysOfWeek dayOfWeek = new DaysOfWeek();
                dayOfWeek.Day = day;
                dayOfWeek.Date = FirstDay.AddDays(daysOfWeek.Count());
                daysOfWeek.Add(dayOfWeek);
            }

            return daysOfWeek;
        }
    }
}