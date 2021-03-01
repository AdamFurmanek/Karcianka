using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour
{
    public Player CurrentPlayer { get; set; }
    public Player OtherPlayer { get; set; }
    public Card SelectedCard { get; set; }

    public void ExecuteOnSecondCard(Card other)
    {
        SelectedCard.UseOnSomething(other);
        SelectedCard = null;
    }

    public void Start()
    {
        //Wywołanie startMatch i wrzucenie dwóch osób do walki.
        //Tak naprawdę będzie to wywoływane gdzie indziej, prawdopodobnie w jakimś gameManagerze.
        StartMatch(new Person(), new Person());
        CleanTable();

    }

    public void StartMatch(Person person0, Person person1)
    {
        //Utworzenie playerów z personów.
        CurrentPlayer = new Player(this, person0);
        OtherPlayer = new Player(this, person1);
    }

    public void CheckDeaths()
    {
        for (int i = CurrentPlayer.cards[2].Count - 1; i >= 0; i--)
            if (CurrentPlayer.cards[2][i].health <= 0)
                CurrentPlayer.cards[2][i].Death();
        for (int i = OtherPlayer.cards[2].Count - 1; i >= 0; i--)
            if (OtherPlayer.cards[2][i].health <= 0)
                OtherPlayer.cards[2][i].Death();
    }

    public void CleanTable()
    {
        for(int i = 0; i < CurrentPlayer.cards[0].Count; i++)
            CurrentPlayer.cards[0][i].gameObject.transform.position = new Vector3(8.0f, (float)i / 100, 2.0f);
        for (int i = 0; i < OtherPlayer.cards[0].Count; i++)
            OtherPlayer.cards[0][i].gameObject.transform.position = new Vector3(8.0f, (float)i / 100, -2.0f);

        for (int i = 0; i < CurrentPlayer.cards[1].Count; i++)
            CurrentPlayer.cards[1][i].gameObject.transform.position = new Vector3(-8.0f + 1.8f * i, 0, 3.3f);
        for (int i = 0; i < OtherPlayer.cards[1].Count; i++)
            OtherPlayer.cards[1][i].gameObject.transform.position = new Vector3(-8.0f + 1.8f * i, 0, -3.3f);

        for (int i = 0; i < CurrentPlayer.cards[2].Count; i++)
            CurrentPlayer.cards[2][i].gameObject.transform.position = new Vector3(-8.0f + 1.8f * i, 0, 1.2f);
        for (int i = 0; i < OtherPlayer.cards[2].Count; i++)
            OtherPlayer.cards[2][i].gameObject.transform.position = new Vector3(-8.0f + 1.8f * i, 0, -1.2f);

        for (int i = 0; i < CurrentPlayer.cards[3].Count; i++)
            CurrentPlayer.cards[3][i].gameObject.transform.position = new Vector3(50.0f, 0, 0);
        for (int i = 0; i < OtherPlayer.cards[3].Count; i++)
            OtherPlayer.cards[3][i].gameObject.transform.position = new Vector3(50.0f, 0, 0);
    }

    public void OnMouseDown()
    {
        SelectedCard = null;
    }

    public void GiveTurn()
    {
        Player temp = CurrentPlayer;
        CurrentPlayer = OtherPlayer;
        OtherPlayer = temp;

        for (int i = CurrentPlayer.cards[2].Count - 1; i >= 0; i--)
            CurrentPlayer.cards[2][i].OnNewTurn();

        CheckDeaths(); //Sprawdź czy ktoś umarł/przegrał.
    }

}
