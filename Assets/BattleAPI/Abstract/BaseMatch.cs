using System.Collections.Generic;

public enum PlayerIds { None, Player, Opponent };

namespace Card
{
    abstract class BaseMatch : IMatch
    {

        public Player Player { get; private set; }
        public Player Opponent { get; private set; }

        public BaseMatch()
        {
            Player = new Player(PlayerIds.Player);
            Opponent = new Player(PlayerIds.Opponent);
        }

        public Player GetPlayer(PlayerIds id)
        {
            return Player.Id == id ? Player : Opponent;
        }

        public Player GetOpponent(PlayerIds id)
        {
            return Player.Id == id ? Opponent : Player;
        }

        public void LoadDeck(PlayerIds playerId, List<BaseCard> deck)
        {
            foreach(BaseCard card in deck)
            {
                card.OwnerId = playerId;
                card.State = this;
            }

            GetPlayer(playerId).Deck = deck;
        }

        public void DrawCard(PlayerIds id)
        {
            GetPlayer(id).Deck[0].ActionMove(Zone.Deck, Zone.Hand);
        }

        public abstract T SendEvent<T>(IEvent<T> e);
        public abstract void SubscribeTrigger(ITriggerObserver observer, ETrigger trigger);
        public abstract void UnSubsribeTrigger(ITriggerObserver observer);
        public abstract void SignalTrigger(BaseCard card, ETrigger trigger);
    }
}
