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
using System.Data.OleDb;

namespace dbApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string data = "";

        OleDbConnection cn;

        public MainWindow()
        {
            InitializeComponent();

            // Absolute file paths for different computers.  One being used now is relative. 
            // C: \Users\geoch\source\repos\dbApp\dbApp\EmployeeDB.accdb
            // C:\\Users\\chrchump\\Desktop\\DatabaseCW\\dbApp\\dbApp\\
            cn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = EmployeeDB.accdb");
        }

        private void assetButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select* from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            data += "Emplyee ID --> Asset --> Value\n";
            while (read.Read())
            {
                data += read[0].ToString() + " --> " + read[1].ToString() + " --> " + read[2].ToString() + "\n";
                AssetBox.Text = data;
            }
            data = "";
            cn.Close();
        }

        private void AssetBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //AssetBox.Text = data;
        }

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select* from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            data += "Emplyee ID --> First Name --> Last Name\n";
            while (read.Read())
            {
                data += read[0].ToString() + " --> " + read[1].ToString() + " --> " + read[2].ToString() + "\n";
                AssetBox.Text = data;
            }
            data = "";
            cn.Close();
        }
    }
}
