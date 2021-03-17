using System.Collections.Generic;

namespace Card
{
    class Player
    {
        public List<BaseCard> Hand { private set; get; } = new List<BaseCard>();
        public List<BaseCard> Deck
        {
            set
            {
                if (_deck == null)
                {
                    _deck = value;
                }
            }
            get => _deck;
        }
        public List<BaseCard> graveyard { private set; get; } = new List<BaseCard>();
        public List<BaseCard> battlefield { private set; get; } = new List<BaseCard>();
        public PlayerIds Id { private set; get; }

        private List<BaseCard> _deck;
        public Player(PlayerIds id)
        {
            this.Id = id;
        }
    }
}
