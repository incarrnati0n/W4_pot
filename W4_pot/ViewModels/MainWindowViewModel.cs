using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using W4_pot.Logic;
using W4_pot.Model;

namespace W4_pot.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        IRaceLogic logic;

        //Középső listboxba fog menni, csak HasLicense = True, Kovinál ez az Army
        public ObservableCollection<Athlete> Race { get; set; }
        //Bal oldali listbox, akárkit fel lehet venni, Ez a barrack
        public ObservableCollection<Athlete> Athletes { get; set; }

        private Athlete selectedFromAthletes;

        public Athlete SelectedFromAthletes
        {
            get { return selectedFromAthletes; }
            set 
            { 
                SetProperty(ref selectedFromAthletes, value);
                (AddToRaceCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Athlete selectedFromRace;

        public Athlete SelectedFromRace
        {
            get { return selectedFromRace; }
            set 
            { 
                SetProperty(ref selectedFromRace, value);
                (RemoveFromRaceCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand AddToRaceCommand { get; set; }
        public ICommand RemoveFromRaceCommand { get; set; }
        public ICommand ViewAthleteCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IRaceLogic>())
        {

        }



        public MainWindowViewModel(IRaceLogic logic)
        {
            this.logic = logic;

            Race = new ObservableCollection<Athlete>();
            Athletes = new ObservableCollection<Athlete>();



            Athletes.Add(new Athlete
            {
                Name = "Zs. Ádám",
                PersonalBest = 120,
                SeasonalBest = 125,
                RaceNumber = 33,
                HasLicense = true,
                HasTeam = true,
            });

            Athletes.Add(new Athlete
            {
                Name = "Sz. Brendon",
                PersonalBest = 200,
                SeasonalBest = 230,
                RaceNumber = 21,
                HasLicense = true,
                HasTeam = false,
            });

            Athletes.Add(new Athlete
            {
                Name = "H. Imre",
                PersonalBest = 130,
                SeasonalBest = 140,
                RaceNumber = 7,
                HasLicense = true,
                HasTeam = true,
            });

            Athletes.Add(new Athlete
            {
                Name = "G. Jakab",
                PersonalBest = 420,
                SeasonalBest = 690,
                RaceNumber = 69,
                HasLicense = false,
                HasTeam = false,
            });



            logic.SetupCollections(Athletes, Race);

            AddToRaceCommand = new RelayCommand(
                () => logic.AddToRace(SelectedFromAthletes),
                () => SelectedFromAthletes != null && SelectedFromAthletes.HasLicense == true
                );

            RemoveFromRaceCommand = new RelayCommand(
                () => logic.RemoveFromRace(SelectedFromRace),
                () => SelectedFromRace != null
                );

            ViewAthleteCommand = new RelayCommand(
                () => logic.ViewAthlete(SelectedFromRace),
                () => SelectedFromRace != null
                );

        }
    }
}
