using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020_Constructor
{
  internal class Date
  {
    private int year, month, day;

    public Date()
    {
      this.year = 1;
      this.month = 1;
      this.day = 1;
    }

    public Date(int year, int month, int day)
    {
      this.year = year;
      this.month = month;
      this.day = day;
    }

    public void PrintDate()
    {
      Console.WriteLine("{0}/{1}/{2}", year, month, day);
    }
  }
}
