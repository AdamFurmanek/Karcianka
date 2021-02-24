using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour
{
    public List<Card>[,] cards =
    {
        {new List<Card>(), new List<Card>(), new List<Card>(), new List<Card>()},
        {new List<Card>(), new List<Card>(), new List<Card>(), new List<Card>()}
    };

    public int currentPlayer;
    public Card selectedCard = null;

    public int OpposingPlayer()
    {
        return currentPlayer == 0 ? 1 : 0;
    }

    public void ExecuteOnSecondCard(Card other)
    {
        Debug.Log("ok");
        selectedCard.UseOnSomething(other);
        selectedCard = null;
    }

    public void Start()
    {
        List<string> playerCards = new List<string>();
        List<string> enemyCards = new List<string>();
        for(int i= 0; i < 10; i++)
        {
            playerCards.Add("Soldier");
            enemyCards.Add("Soldier");
        }

        StartMatch(playerCards, enemyCards);
        CleanTable();

    }

    public void StartMatch(List<string> player0Cards, List<string> player1Cards)
    {
        List<string>[] playersCards = { player0Cards, player1Cards };
        for(int i = 0; i < playersCards.Length; i++)
        {
            for (int j = 0; j < playersCards[i].Count; j++)
            {
                GameObject go = (GameObject)Resources.Load("prefabs/"+ playersCards[i][j], typeof(GameObject));
                Card card = Instantiate(go, new Vector3(0, 0, 0), go.transform.rotation).GetComponent<Card>();
                card.PrepareForBattle(this, i);
            }
        }
    }

    public void CheckDeaths()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = cards[i,2].Count - 1; j >= 0; j--)
            {
                if (cards[i, 2][j].health <= 0)
                    cards[i, 2][j].Death();
            }
        }
    }

    public void CleanTable()
    {
        for (int i = 0; i < cards[0, 0].Count; i++)
            cards[0, 0][i].gameObject.transform.position = new Vector3(8.0f, (float)i / 100, 2.0f);
        for (int i = 0; i < cards[1, 0].Count; i++)
            cards[1, 0][i].gameObject.transform.position = new Vector3(8.0f, (float)i / 100, -2.0f);

        for (int i = 0; i < cards[0, 1].Count; i++)
            cards[0, 1][i].gameObject.transform.position = new Vector3(-8.0f + 1.8f * i, 0, 3.3f);
        for (int i = 0; i < cards[1, 1].Count; i++)
            cards[1, 1][i].gameObject.transform.position = new Vector3(-8.0f + 1.8f * i, 0, -3.3f);

        for (int i = 0; i < cards[0, 2].Count; i++)
            cards[0, 2][i].gameObject.transform.position = new Vector3(-8.0f + 1.8f * i, 0, 1.2f);
        for (int i = 0; i < cards[1, 2].Count; i++)
            cards[1, 2][i].gameObject.transform.position = new Vector3(-8.0f + 1.8f * i, 0, -1.2f);

        for (int i = 0; i < cards[0, 3].Count; i++)
            cards[0, 3][i].gameObject.transform.position = new Vector3(50.0f, 0, 0);
        for (int i = 0; i < cards[1, 3].Count; i++)
            cards[1, 3][i].gameObject.transform.position = new Vector3(50.0f, 0, 0);
    }

    public void OnMouseDown()
    {
        selectedCard = null;
    }

    public void GiveTurn()
    {
        currentPlayer = OpposingPlayer();
        for (int i = 0; i < cards[2,currentPlayer].Count; i++)
            cards[2,currentPlayer][i].OnNewTurn();

        CheckDeaths(); //Sprawdź czy ktoś umarł/przegrał.
    }

}
