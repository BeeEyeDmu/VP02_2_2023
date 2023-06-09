using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _023_RectProp
{
  public class Rectangle
  {
    public double Width { get; set; }
    public double Height { get; set; }
    public Rectangle(double w, double h)
    {
      Width = w;
      Height = h;
    }
    public Rectangle()
    {
      Width = 0;
      Height = 0;
    }

  }
  internal class Program
  {
    static void Main(string[] args)
    {
      Rectangle rect = new Rectangle(1,1);
      Rectangle r = new Rectangle();
      rect.Width = 5;
      rect.Height = 3;

      double area = rect.Width* rect.Height;
      double perimeter = 2*(rect.Width+rect.Height);

      Console.WriteLine("넓이 : " + area);
      Console.WriteLine("둘레 : " + perimeter);
    }
  }
}
