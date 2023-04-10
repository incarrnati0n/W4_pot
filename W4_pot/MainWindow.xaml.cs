using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using W4_pot.Model;

namespace W4_pot
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

        private void Save_click(object sender, RoutedEventArgs e)
        {
            List<Athlete> athletes = new List<Athlete>();
            foreach (var item in lb_race.Items)
            {
                athletes.Add(item as Athlete);
            }

            string JsonData = JsonConvert.SerializeObject(athletes);
            File.WriteAllText(tb_savename.Text + ".json", JsonData);
        }

        private void Load_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
