using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
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

namespace AppJSON
{   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadJson();
        }

        public void LoadJson()
        {

            var url = "https://siasoftsas.com/alejandro/data.json";
            WebClient wc = new WebClient();
            var datos = wc.DownloadString(url);
            ChartTotal.ItemsSource = convertJson(datos);

            DataTable tabla = convertJson(datos);

            bool val_1 = Convert.ToBoolean(tabla.Rows[0]["open"]);
            TX1.Text = val_1 == true ? "ABIERTO" : "CERRADO";
            TX1.Foreground = val_1 == true ? Brushes.Green : Brushes.Red;

            bool val_2 = Convert.ToBoolean(tabla.Rows[1]["open"]);
            TX2.Text = val_2 == true ? "ABIERTO" : "CERRADO";
            TX2.Foreground = val_2 == true ? Brushes.Green : Brushes.Red;

            bool val_3 = Convert.ToBoolean(tabla.Rows[2]["open"]);
            TX3.Text = val_3 == true ? "ABIERTO" : "CERRADO";
            TX3.Foreground = val_3 == true ? Brushes.Green : Brushes.Red;

        }



        public DataTable convertJson(string json)
        {
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
            return dt;            
        }

        



    }
}
