using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019_StaticAndInstanceMethod
{
  internal class Date
  {
    public int year, month, day;

    static int[] days = { 0, 31, 59, 90, 120, 151, 
      181, 212, 243, 273, 304, 334 };
    public static bool IsLeapYear(int year)
    {
      return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
    }

    public int DayOfYear()
    {
      return days[month - 1] + day +
        (month > 2 && IsLeapYear(year) ? 1 : 0);  // 조건연산자
    }
  }
}
