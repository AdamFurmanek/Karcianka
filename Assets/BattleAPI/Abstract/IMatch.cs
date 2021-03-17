using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    public interface IMatch
    {
        T SendEvent<T>(IEvent<T> e);
        void SubscribeTrigger(ITriggerObserver observer, ETrigger trigger);
        void UnSubsribeTrigger(ITriggerObserver observer);

        void SignalTrigger(BaseCard card, ETrigger trigger);
    }
}
