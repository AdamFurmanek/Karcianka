namespace Card
{
    public interface ITriggerObserver
    {
        void OnOtherPlay(BaseCard triggerSource);
        void OnOtherDie(BaseCard triggerSource);
        void OnOtherDraw(BaseCard triggerSource);
        void OnOtherBounce(BaseCard triggerSource);
    }
}
