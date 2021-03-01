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
    public Player player;
    public int status;

    public void PrepareForBattle(Match match, Player player)
    {
        ResetStats();
        this.match = match;
        this.player = player;
        status = 0;
        this.player.cards[0].Add(this);
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
        if (match.SelectedCard == null)
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
                    match.SelectedCard = this;
                    break;
            }
        }
        else
            if (match.SelectedCard != this)
                match.ExecuteOnSecondCard(this);

        match.CheckDeaths();
        match.CleanTable();
    }

    public virtual void DrawACard()
    {
        player.cards[status].Remove(this);
        status = 1;
        player.cards[status].Add(this);
    }

    public virtual void PutOnTable()
    {
        player.cards[status].Remove(this);
        status = 2;
        player.cards[status].Add(this);
    }

    public virtual void UseOnSomething(Card other)
    {
        health = 0;
        other.health = 0;
    }

    public virtual void Death()
    {
        player.cards[status].Remove(this);
        status = 3;
        player.cards[status].Add(this);
    }

    public virtual void Resurrection(int status)
    {

    }

    public virtual void OnNewTurn()
    {

    }
}
