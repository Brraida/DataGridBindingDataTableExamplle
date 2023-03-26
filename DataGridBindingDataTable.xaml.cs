using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Demo
{
    /// <summary>
    /// DataGridBindingDataTable.xaml 的交互逻辑
    /// </summary>
    public partial class DataGridBindingDataTable : Window, INotifyPropertyChanged
    {
        public DataGridBindingDataTable()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        public DataTable MyDataTable
        {
            get
            {
                return _myDataTable;
            }

            set
            {
                if (_myDataTable != value)
                {
                    _myDataTable = value;
                    OnPropertyChanged(nameof(MyDataTable));
                }
            }
        }

        private DataTable CreateDataTable(int row, int col)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < col; i++)
            {
                dt.Columns.Add(new DataColumn("column " + i));
            }
            for (int j = 0; j < row; j++)
            {
                DataRow dr = dt.NewRow();
                for (int k = 0; k < col; k++)
                {
                    dr[k] = "";
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DataTable _myDataTable;

        private int _col;
        private int _row;
        public int Col
        {
            get { return _col; }
            set
            {
                if (_col != value)
                {
                    _col = value;
                    OnPropertyChanged(nameof(Col));
                }
            }
        }

        public int Row
        {
            get { return _row; }
            set
            {
                if (_row != value)
                {
                    _row = value;
                    OnPropertyChanged(nameof(Row));
                }
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            MyDataTable = CreateDataTable(_row, _col);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in MyDataTable.Rows)
            {
                for (int i = 0; i < MyDataTable.Columns.Count; i++)
                {
                    row[i] = i.ToString();
                }
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in MyDataTable.Rows)
            {
                for (int i = 0; i < MyDataTable.Columns.Count; i++)
                {
                    Console.Write(row[i].ToString() + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
