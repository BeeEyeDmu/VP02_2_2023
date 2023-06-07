using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _021_property
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Rectangle r = new Rectangle();
      r.Width = 10.0;
      r.Height = -10.0;
      Console.WriteLine("r의 면적은 {0}", r.Width*r.Height);

      Rectangle2 rect = new Rectangle2();
      rect.Width = 10.0;
      rect.Height = -10.0;
      Console.WriteLine("rect의 면적은 {0}", rect.Width * rect.Height);
    }
  }
}
