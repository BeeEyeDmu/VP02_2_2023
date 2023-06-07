using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020_Constructor
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Date birthday = new Date(2023, 11, 22);
      Date christmas = new Date(2023, 12, 25);
      Date firstDay = new Date();

      birthday.PrintDate();
      christmas.PrintDate();
      firstDay.PrintDate();
    }
  }
}
