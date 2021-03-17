using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    class EmptyCard : Card
    {
        protected override float Evaluate()
        {
            return 0.8f;
        }

        protected override int SetAttack()
        {
            return 1;
        }

        protected override int SetHealth()
        {
            return 1;
        }
    }
}
