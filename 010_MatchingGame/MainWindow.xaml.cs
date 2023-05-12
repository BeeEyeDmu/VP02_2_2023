using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _010_MatchingGame
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    string[] icon = {"딸기", "레몬", "모과", "배", "사과", "수박",
                    "파인애플","포도"};
    int[] rnd = new int[16];

    public MainWindow()
    {
      InitializeComponent();

      BoardSet();
    }

    private void BoardSet()
    {
      for(int i=0; i<16; i++)
      {
        Button c = new Button();
        c.Background = Brushes.White;
        c.Margin = new Thickness(10);        
        c.Tag = TagSet();
        c.Content = MakeImage("../../Images/check.png");
        board.Children.Add(c);
      }
    }

    private Image MakeImage(string v)
    {
      BitmapImage bi = new BitmapImage();
      bi.BeginInit();
      bi.UriSource = new Uri(v, UriKind.Relative);
      bi.EndInit();

      // 비트맵을 이미지로 변환
      Image img = new Image();
      img.Margin = new Thickness(10);
      img.Stretch = Stretch.Fill;
      img.Source = bi;

      return img;
    }

    private int TagSet()
    {
      int i;      
      Random r = new Random();

      while(true)
      {
        i = r.Next(16);
        if(rnd[i] == 0)
        {
          rnd[i] = 1;
          break;
        }
      }
      return i % 8;
    }
  }
}
