using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading; // DispatcherTimer

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

    Button first = null;
    Button second = null;

    int matched = 0;
    // Timer t = new Timer();
    DispatcherTimer myTimer = new DispatcherTimer();

    public MainWindow()
    {
      InitializeComponent();

      BoardSet();

      // 타이머 세팅
      myTimer.Interval = new TimeSpan(0, 0, 0, 0, 750); // 0.75초
      myTimer.Tick += MyTimer_Tick;
    }

    private void MyTimer_Tick(object sender, EventArgs e)
    {
      myTimer.Stop();
      first.Content = MakeImage("../../Images/check.png");
      second.Content = MakeImage("../../Images/check.png");
      first = null;
      second = null;
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
        c.Click += C_Click;
        board.Children.Add(c);
      }
    }

    private void C_Click(object sender, RoutedEventArgs e)
    {
      //Button btn = sender as Button;
      Button btn = (Button)sender;

      string fruitName = icon[(int)btn.Tag];

      if (first == null) // 이 버튼이 첫번째 버튼
      {
        first = btn;
        btn.Content = MakeImage("../../Images/" + fruitName + ".png");
        return;
      }
      else if (second == null) // 이 버튼이 두번째 버튼
      {
        second = btn;
        btn.Content = MakeImage("../../Images/" + fruitName + ".png");
      }
      else
        return;

      // first와 second가 매칭되는지 체크
      if((int)first.Tag == (int)second.Tag) // 매칭이 되었다면
      {
        first = null;
        second = null;
        matched += 2;
        if(matched >= 16)
        {
          MessageBoxResult res = MessageBox.Show(
            "성공했습니다! 다시 시작할까요?", "성공!",
            MessageBoxButton.YesNo);
          if(res == MessageBoxResult.Yes)
          {
            resetRnd();
            board.Children.Clear();
            matched = 0;
            BoardSet();
          }
          else
          {
            this.Close();
          }
        }
      }
      else // 매칭이 안되었다면, 타이머를 이용해서 지연후 그림을 덮는다
      {
        myTimer.Start();
      }
    }

    private void resetRnd()
    {
      for (int i = 0; i < 16; i++)
        rnd[i] = 0;
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
