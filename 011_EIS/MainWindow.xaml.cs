using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace _011_EIS
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    string dept = "";
    string pos = "";
    string gender = "";
    string dateEnter = "";
    string dateExit = "";

    string connStr = "server=localhost; user id=root; password=0000; database=eis2_db";
    MySqlConnection conn;


    public MainWindow()
    {
      InitializeComponent();

      conn = new MySqlConnection(connStr);
      DisplayDataGrid();
    }

    private void btnInsert_Click(object sender, RoutedEventArgs e)
    {
      if (rbMale.IsChecked == true)
        gender = "남성";
      else if (rbFemale.IsChecked == true)
        gender = "여성";

      if (dpEnter.SelectedDate != null)
        dateEnter = dpEnter.SelectedDate.Value.Date.ToShortDateString();
      if (dpExit.SelectedDate != null)
        dateExit = dpExit.SelectedDate.Value.Date.ToShortDateString();
      else
        dateExit = DateTime.MaxValue.ToShortDateString();

      dept = cbDept.Text;
      pos = cbPos.Text;

      conn.Open();

      try
      {
        string sql = string.Format(
          "INSERT INTO eis_table (name, department, position, gender, date_enter, "
          + "date_exit, contact, comment)"
          + "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
          txtName.Text, dept, pos, gender, dateEnter, dateExit,
          txtContact.Text, txtComment.Text);

        MySqlCommand cmd = new MySqlCommand(sql, conn);
        if (cmd.ExecuteNonQuery() == 1)
          MessageBox.Show("성공적으로 추가되었습니다!");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }

      conn.Close();
      InitControls();
      DisplayDataGrid();
    }

    private void InitControls()
    {
      txtEid.Text = "";
      txtName.Text = "";
      txtContact.Text = "";
      txtComment.Text = "";
      cbDept.SelectedIndex = -1;
      cbPos.SelectedIndex = -1;
      rbFemale.IsChecked = false;
      rbMale.IsChecked = false;
      dpEnter.Text = "";
      dpExit.Text = "";
    }

    private void btnLoadData_Click(object sender, RoutedEventArgs e)
    {
      DisplayDataGrid();
    }

    private void DisplayDataGrid()
    {
      conn.Open();

      string sql = "SELECT * FROM eis_table";

      try
      {
        MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dataGrid.ItemsSource = ds.Tables[0].DefaultView;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }

      conn.Close();
    }

    private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      DataGrid dg = sender as DataGrid; // (DataGrid)sender;
      DataRowView rowView = dg.SelectedItem as DataRowView;

      if(rowView == null)
        return;

      txtEid.Text = rowView.Row[0].ToString();
      txtName.Text = rowView.Row[1].ToString();
      cbDept.Text = rowView.Row[2].ToString();
      cbPos.Text = rowView.Row[3].ToString();

      if(rowView.Row[4].ToString() == "남성")
      {
        rbMale.IsChecked = true;
        rbFemale.IsChecked = false;
      }
      else
      {
        rbMale.IsChecked = false;
        rbFemale.IsChecked = true;
      }

      dpEnter.Text = rowView.Row[5].ToString();
      dpExit.Text = rowView.Row[6].ToString();
      txtContact.Text = rowView.Row[7].ToString();
      txtComment.Text = rowView.Row[8].ToString();
    }

    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {
      if (rbMale.IsChecked == true)
        gender = "남성";
      else
        gender = "여성";

      dateEnter = dpEnter.Text;
      dateExit = dpExit.Text;

      dept = cbDept.Text;
      pos = cbPos.Text;                                           

      conn.Open();

      try
      {
        string sql = string.Format(
          "UPDATE eis_table SET name='{0}', department='{1}'," +
          "position='{2}', gender='{3}', date_enter='{4}'," +
          "date_exit='{5}', contact='{6}', comment='{7}' " +
          "WHERE eid={8}",
          txtName.Text, dept, pos, gender, dateEnter, dateExit,
          txtContact.Text, txtComment.Text, txtEid.Text);

        MySqlCommand cmd = new MySqlCommand(sql, conn);
        if (cmd.ExecuteNonQuery() == 1)
          MessageBox.Show("성공적으로 수정되었습니다!");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      conn.Close();
      InitControls();
      DisplayDataGrid();
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
      conn.Open();

      try
      {
        string sql = string.Format("DELETE FROM eis_table WHERE eid={0}",
          txtEid.Text);
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        if (cmd.ExecuteNonQuery() == 1)
          MessageBox.Show("삭제가 성공되었습니다.");
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message);
      }

      conn.Close();
      InitControls();
      DisplayDataGrid();
    }
  }
}
