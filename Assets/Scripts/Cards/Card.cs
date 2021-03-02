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
    public string status;

    public void PrepareForBattle(Match match, Player player)
    {
        ResetStats();
        this.match = match;
        this.player = player;
        status = Place.Stack;
        this.player.cards[status].Add(this);
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
                case "Stack":
                    DrawACard();
                    break;
                case "Hand":
                    PutOnTable();
                    break;
                case "Table":
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
        status = Place.Hand;
        player.cards[status].Add(this);
    }

    public virtual void PutOnTable()
    {
        player.cards[status].Remove(this);
        status = Place.Table;
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
        status = Place.Coffin;
        player.cards[status].Add(this);
    }

    public virtual void Resurrection(int status)
    {

    }

    public virtual void OnNewTurn()
    {

    }
}
