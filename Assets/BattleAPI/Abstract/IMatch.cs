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
