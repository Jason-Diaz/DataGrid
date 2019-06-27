using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Lab_DataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            string connString = @"server = (LocalDB)\MSSQLLocalDB;" +
			"integrated security = SSPI;" +
			"database = Employee";


            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);

            sqlConn.Open();

            // Setup the SQL command
            string sql = "SELECT * FROM Employee";
            SqlCommand command = new SqlCommand(sql, sqlConn);

            // Retrieve the data from the database
            SqlDataReader reader = command.ExecuteReader();

            //*************************************************
            // Associate the DataGrid with the SqlDataReader.
            // This will automatically populate the DataGrid.
            //*************************************************
            DataGridEmployee.ItemsSource = reader;

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            string connString = @"server = (LocalDB)\MSSQLLocalDB;" +
            "integrated security = SSPI;" +
            "database = Employee";

            // Setup the SQL command
            string sql = "DELETE FROM Employee";

            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open();

            SqlCommand command = new SqlCommand(sql, sqlConn);
            int rowsAffected = command.ExecuteNonQuery();

        }
    }
}
