using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W4_pot.Model;
using W4_pot.Services;

namespace W4_pot.Logic
{
    public class RaceLogic : IRaceLogic
    {
        private IList<Athlete> Athletes;
        private IList<Athlete> Race;
        IMessenger messenger;
        IAthleteViewerService viewerservice;

        public RaceLogic(IMessenger messenger, IAthleteViewerService viewerservice)
        {
            this.messenger = messenger;
            this.viewerservice = viewerservice;
        }


        public void SetupCollections(IList<Athlete> Athletes, IList<Athlete> Race)
        {
            this.Athletes = Athletes;
            this.Race = Race;
        }

        public void AddToRace(Athlete athlete)
        {
            Race.Add(athlete.GetCopy());
            messenger.Send("Athlete added", "AthleteInfo");
        }

        public void RemoveFromRace(Athlete athlete)
        {
            Race.Remove(athlete);
            messenger.Send("Athlete removed", "AthleteInfo");
        }

        public void ViewAthlete(Athlete athlete)
        {
            viewerservice.View(athlete);
        }
    }
}
