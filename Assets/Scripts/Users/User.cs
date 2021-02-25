using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Users
{
    public class User
    {
        public int Id { get; private set; } //todo moze niepotrzebne? Nie pamietam zastosowania, potrzebne w metodzie OpposingPlayer()
        public IEnumerable<Card> Cards { get; set; } = Enumerable.Repeat(new SoldierCard(), 10);

        //todo trzeba dac jakies domyslne wartosci tutaj dla tego slownika
        public Dictionary<string, IEnumerable<Card>> CardsPlaces { get; set; } = new Dictionary<string, IEnumerable<Card>>
        {
            { Place.Hand, new List<Card>() },
            {  Place.Coffin, new List<Card>() },
            { Place.Table, new List<Card>() }
        };
        
        public User()
        {
        }

        public User(int id)
        {
            Id = id;
        }
    }
}
