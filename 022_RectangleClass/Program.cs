using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Rectangle
{
  private double width;
  private double height;

  public void SetWidth(double w)
  {
    width = w;
  }
  //public Rectangle(double w, double h)
  //{
  //  this.width = w;
  //  this.height = h;
  //}

  public double GetArea()
  {
    return width * height;
  }

  public double GetPerimeter()
  {
    return 2 * (width + height);
  }

}
public class Program
{
  static void Main(string[] args)
  {
    Rectangle rect = new Rectangle();
    rect.SetWidth(5);

    double area = rect.GetArea();
    double perimeter = rect.GetPerimeter();

    Console.WriteLine("넓이 : " + area);
    Console.WriteLine("둘레 : " + perimeter);
  }
}

