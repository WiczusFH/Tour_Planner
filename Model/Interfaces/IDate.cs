using System;

namespace Model
{
    public interface IDate
    {
        int day { get; set; }
        int month { get; set; }
        int year { get; set; }
        public string ToString();
    }
}
