using System;
using System.Collections.Generic;
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

namespace Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyDatatable = GetDataTable();
            //DataContext = this;
            dg.ItemsSource = MyDatatable.DefaultView;
        }

        public DataTable MyDatatable { get; set; }

        private DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name",System.Type.GetType("System.String"));
            dt.Columns.Add("Age",System.Type.GetType("System.Int32"));
            dt.Columns.Add("City",System.Type.GetType("System.String"));

            DataRow dataRow = dt.NewRow();
            dataRow["Name"] = "mark";
            dataRow["Age"] = 23;
            dataRow["City"] = "LA";
            dt.Rows.Add(dataRow);
            

            return dt;
        }
    }
}
