using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019_StaticAndInstanceMethod
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Date xmas = new Date();
      xmas.year = 2023;
      xmas.month = 12;
      xmas.day = 25;

      Console.WriteLine("xmas :{0}/{1}/{2}는 {3}일째 되는 날입니다",
        xmas.year, xmas.month, xmas.day, xmas.DayOfYear());
      if(Date.IsLeapYear(2023) == true)
        Console.WriteLine("2023년은 윤년입니다.");
      else
        Console.WriteLine("2023년은 평년입니다.");
    }
  }
}
