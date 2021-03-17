using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    class SummonerCard : Card
    {
        protected override float Evaluate()
        {
            return 1.2f;
        }

        override protected void OnDraw()
        {
            // ActionMove(Zone.Hand, Zone.Battlefield, 0); // <--- Do activate onPlay()
            // ActionPut(Zone.Hand, Zone.Battlefield, 0) <--- Do not activate onPlay()
        }

        override protected void OnPlay()
        {
            State.SendEvent(new CreateCardEvent(this, new EmptyCard()));
        }

        protected override int SetAttack()
        {
            return 2;
        }

        protected override int SetHealth()
        {
            return 1;
        }
    }
}
