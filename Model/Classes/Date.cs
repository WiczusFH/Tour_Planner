using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model
{
    public class Date : IDate
    {
        public bool valid { get; private set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }

        public string ToString()
        {
            if (valid)
            {
                StringBuilder sb = new StringBuilder();
                if (day < 10)
                {
                    sb.Append(0);
                }
                sb.Append(day);
                sb.Append(".");
                if (month < 10)
                {
                    sb.Append(0);
                }
                sb.Append(month);
                sb.Append(".");
                sb.Append(year);
                return sb.ToString();
            }
            return "";
        }

        public enum months
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }
        public Date()
        {
            valid = false;
        }
        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
            if(day>=1 && day<=31 && month>=1 && month <= 12)
            {
                valid = true;
            } else
            {
                valid = false;
            }
        }
        public static Date fromString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new Date();
            }

            string[] dotFormat = input.Split('.');
            if (dotFormat.Length == 3)
            {
                if (dotFormat[0].Length == 4)
                {
                    return new Date(Int32.Parse(dotFormat[2]), Int32.Parse(dotFormat[1]), Int32.Parse(dotFormat[0]));
                }
                return new Date(Int32.Parse(dotFormat[0]), Int32.Parse(dotFormat[1]), Int32.Parse(dotFormat[2]));
            }

            string[] dashFormat = input.Split('-');
            if (dashFormat.Length == 3)
            {
                if (dashFormat[0].Length == 4)
                {
                    return new Date(Int32.Parse(dashFormat[2]), Int32.Parse(dashFormat[1]), Int32.Parse(dashFormat[0]));
                }
                return new Date(Int32.Parse(dashFormat[0]), Int32.Parse(dashFormat[1]), Int32.Parse(dashFormat[2]));
            }

            string[] slashFormat = input.Split('/');
            if (slashFormat.Length == 3)
            {
                if (slashFormat[0].Length == 4)
                {
                    return new Date(Int32.Parse(slashFormat[2]), Int32.Parse(slashFormat[1]), Int32.Parse(slashFormat[0]));
                }
                return new Date(Int32.Parse(slashFormat[0]), Int32.Parse(slashFormat[1]), Int32.Parse(slashFormat[2].Split(' ')[0]));
            }
            Type monthsType = typeof(months);
            int i = 0;
            foreach (var monthName in monthsType.GetFields())
            {
                if (input.Contains(monthName.Name))
                {
                    string[] rest = input.Split(monthName.Name);
                    return new Date(Int32.Parse(rest[0]), i, Int32.Parse(rest[1]));
                }
                i++;
            }
            throw new ArgumentException("Could not create Date, please use the enumerator names for Months and separate with whitespace, or use numbers separated by '.', '-' or '/'. ", input);
        }
    }
}
