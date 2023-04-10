using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4_pot.Model
{
    public class Athlete : ObservableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private int personalBest;

        public int PersonalBest
        {
            get { return personalBest; }
            set { SetProperty(ref personalBest, value); }
        }

        private int seasonalBest;

        public int SeasonalBest
        {
            get { return seasonalBest; }
            set { SetProperty(ref seasonalBest, value); }
        }

        private bool hasLicense;

        public bool HasLicense
        {
            get { return hasLicense; }
            set { SetProperty(ref hasLicense, value); }
        }

        private bool hasTeam;

        public bool HasTeam
        {
            get { return hasTeam; }
            set { SetProperty(ref hasTeam, value); }
        }

        private int raceNumber;

        public int RaceNumber
        {
            get { return raceNumber; }
            set { SetProperty(ref raceNumber, value); }
        }


        public int Value
        {
            get
            {
                return personalBest * seasonalBest;
            }
        }

        public Athlete GetCopy()
        {
            return new Athlete()
            {
                Name = this.Name,
                PersonalBest = this.PersonalBest,
                SeasonalBest = this.SeasonalBest,
                HasLicense = this.HasLicense,
                HasTeam = this.HasTeam,
                RaceNumber = this.RaceNumber,
            };
        }


    }
}
