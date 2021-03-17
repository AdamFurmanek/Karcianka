namespace Card
{
    public abstract class BaseCard : Entity, ITriggerObserver
    {
        public PlayerIds OwnerId { get; set; } = PlayerIds.None;
        public PlayerIds ControllerId { get; set; } = PlayerIds.None;
        public Zone CurrentZone { get; set; }
        public int Cost { get; set; }
        public IMatch State { get => _state; set { _state = value; LcStart(); } }

        private IMatch _state;

        public void LcStart()
        {
            SetTriggers();
            SetStatistics();
        }

        public void LcEnd()
        {
            State.UnSubsribeTrigger(this);
        }

        public abstract void ActionMove(Zone src, Zone dest, int position = 0);

        public abstract void ActionAttack();

        public abstract void ActionUse();

        public virtual void OnOtherPlay(BaseCard triggerSource) { }

        public virtual void OnOtherDie(BaseCard triggerSource) { }

        public virtual void OnOtherDraw(BaseCard triggerSource) { }

        public virtual void OnOtherBounce(BaseCard triggerSource) { }

        protected abstract int SetHealth();
        protected abstract int SetAttack();
        protected virtual void SetTriggers() { }

        protected abstract void ActionPut(Zone src, Zone dest, int position);

        protected virtual void OnPlay() { }

        protected virtual void OnDie() { }

        protected virtual void OnBounce() { }

        protected virtual void OnDraw() { }

        protected abstract float Evaluate();
        private void SetStatistics()
        {
            BaseHealth = SetHealth();
            Attack = SetAttack();
        }

    }
}
