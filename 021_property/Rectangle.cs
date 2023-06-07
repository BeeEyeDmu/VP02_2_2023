using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _021_property
{
  internal class Rectangle
  {
    public double Width { get; set; }
    public double Height { get; set; }
  }

  public class Rectangle2
  {
    private double width;

    public double Width
    {
      get { return width; }
      set { if(value > 0) width = value; }
    }

    private double height;

    public double Height
    {
      get { return height; }
      set { if (value > 0) height = value; }
    }


  }
}
