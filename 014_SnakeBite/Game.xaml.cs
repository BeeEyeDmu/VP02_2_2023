using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _014_SnakeBite
{
  /// <summary>
  /// Game.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class Game : Window
  {
    private Ellipse[] snakes = new Ellipse[30];
    private Ellipse egg;
    private Random r = new Random();
    private int size = 10;          // 알과 뱀의 크기
    private int visibleCount = 5;

    private string move = "";   // 움직이는 방향
    private int eaten = 0;      // 먹은 갯수
    DispatcherTimer timer = new DispatcherTimer();
    Stopwatch sw = new Stopwatch(); 

    public Game() // 생성자
    {
      InitializeComponent();
      InitEgg();
      InitSnakes();

      timer.Interval = new TimeSpan(0, 0, 0, 0, 100); // 0.1초마다
      timer.Tick += Timer_Tick;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      
    }

    private void InitSnakes()
    {
      int x = r.Next(1, (int)field.Width / size - 1);
      int y = r.Next(1, (int)field.Height / size - 5);

      for(int i=0;i<30; i++)
      {
        snakes[i] = new Ellipse();
        snakes[i].Width = size;
        snakes[i].Height = size;
        if (i % 5 == 0)
          snakes[i].Fill = Brushes.Green;
        else
          snakes[i].Fill = Brushes.Gold;
        snakes[i].Stroke = Brushes.Black;
        field.Children.Add(snakes[i]);
        snakes[i].Tag = new Point(x * size, (y+i) * size);
        Canvas.SetLeft(snakes[i], x * size);
        Canvas.SetTop(snakes[i], (y + i)*size);
      }
      snakes[0].Fill = Brushes.Chocolate;

      for(int i= visibleCount; i<30; i++)
        snakes[i].Visibility = Visibility.Hidden;
    }

    private void InitEgg()
    {
      egg = new Ellipse();
      egg.Width = size;
      egg.Height = size;
      egg.Stroke = Brushes.Black;
      egg.Fill = Brushes.Red;

      int x = r.Next(1, (int)field.Width / size - 1);
      int y = r.Next(1, (int)field.Height / size - 1);

      egg.Tag = new Point(x * size, y * size);
      field.Children.Add(egg);
      Canvas.SetLeft(egg, x * size);
      Canvas.SetTop(egg, y * size);
    }
  }
}
