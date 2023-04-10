using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W4_pot.Model;

namespace W4_pot.ViewModels
{
    public class AthleteViewerWindowViewModel
    {
        public Athlete Actual { get; set; }

        public void Setup(Athlete athlete)
        {
            this.Actual = athlete;
        }

        public AthleteViewerWindowViewModel()
        {

        }
    }
}
