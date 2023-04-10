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
using System.Windows.Shapes;
using W4_pot.Model;
using W4_pot.ViewModels;

namespace W4_pot
{
    /// <summary>
    /// Interaction logic for AthleteViewerWindow.xaml
    /// </summary>
    public partial class AthleteViewerWindow : Window
    {
        public AthleteViewerWindow(Athlete athlete)
        {
            InitializeComponent();
            var vm = new AthleteViewerWindowViewModel();
            vm.Setup(athlete);
            this.DataContext = vm;
        }
    }
}
