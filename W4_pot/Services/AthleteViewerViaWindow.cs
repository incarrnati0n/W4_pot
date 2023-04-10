using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W4_pot.Model;

namespace W4_pot.Services
{
    public class AthleteViewerViaWindow : IAthleteViewerService
    {
        public void View(Athlete athlete)
        {
            //window show
            new AthleteViewerWindow(athlete).ShowDialog();
        }
    }
}
