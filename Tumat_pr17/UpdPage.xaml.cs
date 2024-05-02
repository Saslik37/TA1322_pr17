using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Configuration;

namespace Tumat_pr17
{
    /// <summary>
    /// Логика взаимодействия для UpdPage.xaml
    /// </summary>
    public partial class UpdPage : Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlDataAdapter adapter;
        DataTable AeroportTable;
        SqlConnection connection = null;
        public UpdPage()
        {
            InitializeComponent();
        }

        private void upd_Click(object sender, RoutedEventArgs e)
        {
            if (name_box.Text != "" && date_box.Text != "" && capacity_box.Text != "" && to_box.Text != "" && hours_box.Text != "")
            {
                string sql = $"update Airplanes set airplane_name = '{name_box.Text}', date_of_issue = '{date_box.Text}', " +
                    $"capacity = {capacity_box.Text}, last_tech_service = '{to_box.Text}', flight_hours = {hours_box.Text} " +
                    $"where airplane_id = {id_box.Text}";
                AeroportTable = new DataTable();

                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    adapter = new SqlDataAdapter(command);
                    MessageBox.Show("Данные обновлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                    if (connection != null)
                        connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Не все ");
            }
        }
    }
}
