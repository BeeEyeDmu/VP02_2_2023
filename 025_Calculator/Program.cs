using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _025_Calculator
{
  public class Calculator
  {
    public static int Add(int n1, int n2)
    { return n1 + n2; }
    public static int Subtract(int n1, int n2)
    { return n1 - n2; }

  }
  internal class Program
  {
    static void Main(string[] args)
    {
      int n1 = 10;
      int n2 = 20;
      int sum = Calculator.Add(n1, n2);
      int diff = Calculator.Subtract(n1, n2);
      Console.WriteLine("덧셈 : " + sum);
      Console.WriteLine("뺄셈 : " + diff);
      //Calculator c = new Calculator();
      //int sum = c.Add(n1, n2);
    }
  }
}
