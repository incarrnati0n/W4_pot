using System.Collections.Generic;
using W4_pot.Model;

namespace W4_pot.Logic
{
    public interface IRaceLogic
    {
        void AddToRace(Athlete athlete);
        void RemoveFromRace(Athlete athlete);
        void SetupCollections(IList<Athlete> Athletes, IList<Athlete> Race);

        void ViewAthlete(Athlete athlete);
    }
}