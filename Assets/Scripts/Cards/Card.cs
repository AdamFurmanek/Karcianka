using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public float oAttack, oDefense, oHealth;
    public float attack, defense, health;
    public int oUses, oSleeps;
    public int uses, sleeps;

    public Match match;
    public int status;
    public int player;

    public void PrepareForBattle(Match match, int player)
    {
        this.match = match;
        ResetStats();
        this.player = player;
        status = 0;
        match.cards[player, status].Add(this);
    }

    public void ResetStats()
    {
        attack = oAttack;
        defense = oDefense;
        health = oHealth;
        uses = oUses;
        sleeps = oSleeps;
    }

    public void OnMouseDown()
    {
        if (match.selectedCard == null)
        {
            switch (status)
            {
                case 0:
                    DrawACard();
                    break;
                case 1:
                    PutOnTable();
                    break;
                case 2:
                    match.selectedCard = this;
                    break;
            }
        }
        else
            if (match.selectedCard != this)
                match.ExecuteOnSecondCard(this);

        match.CheckDeaths();
        match.CleanTable();
    }

    public virtual void DrawACard()
    {
        match.cards[player, status].Remove(this);
        status = 1;
        match.cards[player, status].Add(this);
    }

    public virtual void PutOnTable()
    {
        match.cards[player, status].Remove(this);
        status = 2;
        match.cards[player, status].Add(this);
    }

    public virtual void UseOnSomething(Card other)
    {
        health = 0;
        other.health = 0;
    }

    public virtual void Death()
    {
        match.cards[player, status].Remove(this);
        status = 3;
        match.cards[player, status].Add(this);
    }

    public virtual void Resurrection(int status)
    {

    }

    public virtual void OnNewTurn()
    {

    }
}
