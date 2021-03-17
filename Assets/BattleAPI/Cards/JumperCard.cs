using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    class JumperCard : Card
    {
        protected override void SetTriggers()
        {
            State.SubscribeTrigger(this, ETrigger.onDraw);
        }

        public override void OnOtherDraw(BaseCard card)
        {
            if(CurrentZone == Zone.Battlefield)
            {
                State.SendEvent(new MoveCardEvent(card, Zone.Hand, Zone.Battlefield));
            }
        }

        protected override int SetHealth()
        {
            return 1;
        }

        protected override int SetAttack()
        {
            return 0;
        }

        protected override float Evaluate()
        {
            return 5;
        }
    }
}
