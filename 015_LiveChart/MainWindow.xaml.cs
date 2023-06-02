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
using LiveCharts;
using LiveCharts.Wpf;

namespace _015_LiveChart
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    // 필드: 멤버 변수: 소문자로 시작하는 것이 관례
    private int xCount = 0;

    // 속성(property) - 대문자로 시작하는 것이 관례
    public SeriesCollection SeriesCollection { get; set; }
    public string[] XMarks { get; set; }
    public Func<double, string> Values { get; set; }

    public MainWindow()
    {
      InitializeComponent();

      // LiveChart에 Bining해서 표시할 데이터는
      // MainWindow 클래스의 속성으로 정의한다
      SeriesCollection = new SeriesCollection
      {
        new ColumnSeries  // LineSeries는 선그래프
        {
          Title = "2020",
          Values = new ChartValues<double> { 3, 5, 7, 6, 3, 8 }
        },
        new ColumnSeries
        {
          Title = "2021",
          Values = new ChartValues<double> { 4, 5, 8, 9, 4, 6 }
        },
        new ColumnSeries
        {
          Title = "2022",
          Values = new ChartValues<double> { 6, 9, 11, 15, 8, 10 }
        }
      };
      ColumnSeries ls = new ColumnSeries();
      ls.Title = "2023";
      ls.Values = new ChartValues<double> { 5, 5, 7, 8, 9, 15 };
      SeriesCollection.Add(ls);

      XMarks = new string[] { "Kang", "Cho", "Kim", 
        "Song", "Park", "Choi" };
      Values = value => value.ToString("N");

      DataContext = this; // 데이터 바인딩 
    }
  }
}
