using Assets.BattleAPI.Zones;
using Card;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Table : MonoBehaviour
{
    public GameObject cardGameObjectTemplate;
    List<CardGameObject> cardsGameObjects = new List<CardGameObject>();
    public void Start()
    {
        //Na starcie Table musi przyjąć listę kart gracza i przeciwnika (lub po prostu gracza i przeciwnika).
        //Dla każdej z kart musi stworzyć CardGameObject i dodać go do swojej listy, żeby na nim operować.

        var m = new Match();
        var playerCards = new List<BaseCard>();
        var opponentCards = new List<BaseCard>();
        var crd = new JumperCard();
        var crd2 = new SummonerCard();

        playerCards.Add(crd2);
        playerCards.Add(crd);
        playerCards.Add(new SummonerCard());
        playerCards.Add(new SummonerCard());
        opponentCards.Add(new SummonerCard());
        opponentCards.Add(new SummonerCard());
        opponentCards.Add(new SummonerCard());
        opponentCards.Add(new SummonerCard());
        opponentCards.Add(new SummonerCard());

        InstantiateCards(playerCards);
        InstantiateCards(opponentCards);

        m.LoadDeck(PlayerIds.Player, playerCards);
        m.LoadDeck(PlayerIds.Opponent, opponentCards);
        m.DrawCard(PlayerIds.Player);
        crd2.ActionMove(Zone.Hand, Zone.Battlefield);
        m.DrawCard(PlayerIds.Player);
        crd.ActionMove(Zone.Hand, Zone.Battlefield);
        m.DrawCard(PlayerIds.Player);
    }

    private void InstantiateCards(IEnumerable<BaseCard> cards)
    {
        foreach (var card in cards)
        {
            var cardGO = Instantiate(cardGameObjectTemplate, cardGameObjectTemplate.transform.position, cardGameObjectTemplate.transform.rotation).GetComponent<CardGameObject>();
            cardGO.Card = card;
            cardsGameObjects.Add(cardGO);
        }
    }

    public void Update()
    {
        CleanTable();
    }

    private void CleanTable()
    {
        var zonesCardsCounter = new Dictionary<Zone, int>();
        foreach (var zone in Enum.GetValues(typeof(Zone)))
        {
            var zoneCounter = cardsGameObjects.Where(c => c.Card.CurrentZone.Equals(zone)).Count();
            zonesCardsCounter.Add((Zone)zone, zoneCounter); //todo chyba dziala
        }

        foreach (var cardGO in cardsGameObjects)
        {
            var card = cardGO.Card;

            var z = 0;
            if (card.ControllerId == PlayerIds.Player || card.ControllerId == PlayerIds.None && card.OwnerId == PlayerIds.Player)
            {
                z = -1;
            }
            else if (card.ControllerId == PlayerIds.Opponent || card.ControllerId == PlayerIds.None && card.OwnerId == PlayerIds.Opponent)
            {
                z = 1;
            }

            var vector = ZoneHelper.GetPosition(card.CurrentZone, z);
            cardGO.gameObject.transform.position = new Vector3(vector.X, vector.Y, vector.Z);
        }
    }
}
