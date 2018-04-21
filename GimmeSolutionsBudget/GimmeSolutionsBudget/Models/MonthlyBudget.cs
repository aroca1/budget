using System;
using System.Collections.Generic;
using System.Text;

namespace GimmeSolutionsBudget.Models
{
    class MonthlyBudget
    {
        public Dictionary<Category, double> Categories { get; set; }
        public DateTime StartDateTime { get { return _startDateTime; } }
        public DateTime EndDateTime { get { return _endDateTime; } }
        private DateTime _startDateTime;
        private DateTime _endDateTime;

        public MonthlyBudget()
        {
            DateTime now = DateTime.Now;
            _startDateTime = new DateTime(now.Year, now.Month, 1);
            _endDateTime = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));
        }

        public MonthlyBudget(int month, int year)
        {
            _startDateTime = new DateTime(year, month, 1);
            _endDateTime = new DateTime(year, month, DateTime.DaysInMonth(year, month));
        }
    }
}
