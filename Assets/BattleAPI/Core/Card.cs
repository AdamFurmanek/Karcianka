using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    public abstract class Card : BaseCard
    {
        override protected void ActionPut(Zone src, Zone dest, int position)
        {
            State.SendEvent(new MoveCardEvent(this, src, dest, position));
        }

        override public void ActionMove(Zone src, Zone dest, int position = 0)
        {
            ActionPut(src, dest, position);
            if (src == Zone.Hand && dest == Zone.Battlefield)
            {
                ControllerId = OwnerId;
                OnPlay();
            }

            if (src == Zone.Battlefield && dest == Zone.Graveyard)
            {
                OnDie();
            }

            if (src == Zone.Battlefield && dest == Zone.Hand)
            {
                OnBounce();
            }

            if (src == Zone.Deck && dest == Zone.Hand)
            {
                OnDraw();
                State.SignalTrigger(this, ETrigger.onDraw);
            }
        }

        public override void ActionAttack()
        {
            throw new NotImplementedException();
        }

        public override void ActionUse()
        {
            throw new NotImplementedException();
        }
    }
}
