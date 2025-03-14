using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    public class Validator
    {
        public string Date { get; set; }
        private int _numberOfElementsAfterSplit = 3;
        private string[] _splittedDate;
        private const int dayIndex = 0;
        private const int monthIndex = 1;
        private const int yearIndex = 2;
        private const int minMonthValue = 1;
        private const int maxMonthValue = 12;
        private const int minYearValue = 2000;
        private readonly int maxYearValue;
        private const int minDayValue = 1;
        private const int maxDayValue = 31;

        public Validator(string date)
        {
            Date = date;
            _splittedDate = Date.Split('-');
            maxYearValue = DateTime.Now.Year;
        }

        public bool IsValid()
        {
            return CheckNumberOfDashes()
                && CheckElementsAreNumerics()
                && CheckMonthValue()
                && CheckYearValue()
                && CheckDayValue();
        }

        public bool CheckNumberOfDashes()
        {
            return _splittedDate.Length == _numberOfElementsAfterSplit;
        }

        public bool CheckElementsAreNumerics()
        {
            return int.TryParse(_splittedDate[dayIndex], out _) 
                && int.TryParse(_splittedDate[monthIndex], out _)
                && int.TryParse(_splittedDate[yearIndex], out _);
        }

        public bool CheckMonthValue()
        {
            ThrowExceptionIfElementsAreNotNumeric();

            return Convert.ToInt32(_splittedDate[monthIndex]) >= minMonthValue 
                && Convert.ToInt32(_splittedDate[monthIndex]) <= maxMonthValue;
        }

        public bool CheckYearValue()
        {
            ThrowExceptionIfElementsAreNotNumeric();

            return Convert.ToInt32(_splittedDate[yearIndex]) >= minYearValue
                && Convert.ToInt32(_splittedDate[yearIndex]) <= maxYearValue;
        }

        public bool CheckDayValue()
        {
            ThrowExceptionIfElementsAreNotNumeric();

            return Convert.ToInt32(_splittedDate[dayIndex]) >= minDayValue
                && Convert.ToInt32(_splittedDate[dayIndex]) <= maxDayValue;
        }

        public void ThrowExceptionIfElementsAreNotNumeric()
        {
            if (!CheckElementsAreNumerics())
                throw new ArgumentException("Au moins un élément n'est pas numérique");
        }
    }
}
