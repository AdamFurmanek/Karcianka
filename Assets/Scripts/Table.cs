using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;
using System;
using System.Linq;

public class Table : MonoBehaviour
{
    public GameObject cardGameObjectTemplate;
    List<CardGameObject> cardsGameObjects = new List<CardGameObject>();
    void Start()
    {
        //Na starcie Table musi przyjąć listę kart gracza i przeciwnika (lub po prostu gracza i przeciwnika).
        //Dla każdej z kart musi stworzyć CardGameObject i dodać go do swojej listy, żeby na nim operować.

        BaseMatch m = new Match();
        List<BaseCard> playerCards = new List<BaseCard>();
        List<BaseCard> opponentCards = new List<BaseCard>();
        Card.Card crd = new JumperCard();
        Card.Card crd2 = new SummonerCard();
        playerCards.Add(crd2);
        playerCards.Add(crd);
        playerCards.Add(new SummonerCard());
        playerCards.Add(new SummonerCard());
        opponentCards.Add(new SummonerCard());
        opponentCards.Add(new SummonerCard());
        opponentCards.Add(new SummonerCard());
        opponentCards.Add(new SummonerCard());
        opponentCards.Add(new SummonerCard());

        foreach (var card in playerCards)
        {
            CardGameObject cardGO = Instantiate(cardGameObjectTemplate, cardGameObjectTemplate.transform.position, cardGameObjectTemplate.transform.rotation).GetComponent<CardGameObject>();
            cardGO.Card = card;
            cardsGameObjects.Add(cardGO);
        }
        foreach (var card in opponentCards)
        {
            CardGameObject cardGO = Instantiate(cardGameObjectTemplate, cardGameObjectTemplate.transform.position, cardGameObjectTemplate.transform.rotation).GetComponent<CardGameObject>();
            cardGO.Card = card;
            cardsGameObjects.Add(cardGO);
        }

        m.LoadDeck(PlayerIds.Player, playerCards);
        m.LoadDeck(PlayerIds.Opponent, opponentCards);
        m.DrawCard(PlayerIds.Player);
        crd2.ActionMove(Zone.Hand, Zone.Battlefield);
        m.DrawCard(PlayerIds.Player);
        crd.ActionMove(Zone.Hand, Zone.Battlefield);
        m.DrawCard(PlayerIds.Player);
    }

    void Update()
    {
        CleanTable();
    }

    void CleanTable()
    {
        /*
        foreach(var zone in Enum.GetValues(typeof(Zone)))
        {
            var x = cardsGameObjects.Where(c => c.Card.CurrentZone == typeof(zone))
        }
        */

        foreach (var cardGO in cardsGameObjects)
        {
            BaseCard card = cardGO.Card;

            int z = 0;
            if (card.ControllerId == PlayerIds.Player || card.ControllerId == PlayerIds.None && card.OwnerId == PlayerIds.Player)
                z = -1;
            else if (card.ControllerId == PlayerIds.Opponent || card.ControllerId == PlayerIds.None && card.OwnerId == PlayerIds.Opponent)
                z = 1;

            if (card.CurrentZone == Zone.Deck)
                cardGO.gameObject.transform.position = new Vector3(8.0f, 0, 2.0f * z);
            else if(card.CurrentZone == Zone.Hand)
                cardGO.gameObject.transform.position = new Vector3(-8.0f, 0, 3.3f * z);
            else if (card.CurrentZone == Zone.Battlefield)
                cardGO.gameObject.transform.position = new Vector3(-8.0f, 0, 1.2f * z);
            else if (card.CurrentZone == Zone.Graveyard)
                cardGO.gameObject.transform.position = new Vector3(50.0f, 0, 0.0f * z);

        }
    }
}
