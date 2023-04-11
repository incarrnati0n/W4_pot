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
using W4_pot.Logic;
using W4_pot.Model;
using W4_pot.ViewModels;

namespace W4_pot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //MainWindowViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            //vm = new MainWindowViewModel();

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
            var vm = this.DataContext as MainWindowViewModel;
            vm.Athletes.Add(new Athlete
            {
                Name = "Zs. Ádám",
                PersonalBest = 120,
                SeasonalBest = 125,
                RaceNumber = 33,
                HasLicense = true,
                HasTeam = true,
            });

            vm.Athletes.Add(new Athlete
            {
                Name = "Sz. Brendon",
                PersonalBest = 200,
                SeasonalBest = 230,
                RaceNumber = 21,
                HasLicense = true,
                HasTeam = false,
            });

            vm.Athletes.Add(new Athlete
            {
                Name = "H. Imre",
                PersonalBest = 130,
                SeasonalBest = 140,
                RaceNumber = 7,
                HasLicense = true,
                HasTeam = true,
            });

            vm.Athletes.Add(new Athlete
            {
                Name = "G. Jakab",
                PersonalBest = 420,
                SeasonalBest = 690,
                RaceNumber = 69,
                HasLicense = false,
                HasTeam = false,
            });

            vm.logic.SetupCollections(vm.Athletes, vm.Race);

        }
    }
}
