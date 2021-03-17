namespace Card
{
    class CreateCardEvent : Event<BaseCard>
    {
        private Card source;
        private Card creation;
        public CreateCardEvent(Card source, Card creation)
        {
            this.source = source;
            this.creation = creation;
        }
        public BaseCard Activate(BaseMatch match)
        {
            creation.State = match;
            match.GetPlayer(source.ControllerId).battlefield.Add(creation);
            return creation;
        }
    }
}
