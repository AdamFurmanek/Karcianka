using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    class MoveCardEvent : Event<object>
    {
        private readonly Zone src;
        private readonly Zone dest;
        private readonly int pos;
        private readonly BaseCard card;
        public MoveCardEvent(BaseCard card, Zone src, Zone dest, int pos = 0)
        {
            this.src = src;
            this.dest = dest;
            this.pos = pos;
            this.card = card;
        }
        public object Activate(BaseMatch match)
        {
            Player p = match.GetPlayer(card.OwnerId);
            GetZoneAsList(p, src).Remove(card);
            GetZoneAsList(p, dest).Insert(pos, card);
            card.CurrentZone = dest;
            return null;
        }

        protected List<BaseCard> GetZoneAsList(Player p, Zone zone)
        {
            // NB Potentially better solution is map of Zones where key is Zone enum, and value List<Card>
            switch(zone)
            {
                case Zone.Battlefield:
                    return p.battlefield;
                case Zone.Deck:
                    return p.Deck;
                case Zone.Graveyard:
                    return p.graveyard;
                case Zone.Hand:
                    return p.Hand;
                default:
                    throw new Exception();
            }
        }
    }
}
