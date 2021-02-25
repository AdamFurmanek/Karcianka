using Assets.Scripts.Users;
using System.Collections.Generic;
using System.Linq;


// todo w ktorym momencie pojawiaja sie userzy? Tzn gdzie oni sa przypisywani? Mozna ich tu dodac w konstruktorze?
public class Match : MonoBehaviour
{
    //public IEnumerable<IEnumerable<Card>> Cards { get; set; } = new List<IEnumerable<Card>>
    //{
    //    { new List<Card>(), new List<Card>(), new List<Card>(), new List<Card>() },
    //    { new List<Card>(), new List<Card>(), new List<Card>(), new List<Card>() }
    //};

    public User CurrentPlayer { get; set; }
    public User EnemyUser { get; set; }

    //public int currentPlayer;

    public Card SelectedCard { get; set; } = null;
    //public Card selectedCard = null;

    public int OpposingPlayer()
    {
        return CurrentPlayer.Id == 0 ? 1 : 0;
    }

    public void ExecuteOnSecondCard(Card other)
    {
        Debug.Log("ok");
        SelectedCard.UseOnSomething(other);
        SelectedCard = null;
    }

    public void Start()
    {
        StartMatch(CurrentPlayer.Cards.ToList(), EnemyUser.Cards.ToList());
        CleanTable();
    }

    public void StartMatch(List<Card> player0Cards, List<Card> player1Cards)
    {
        //todo nie do konca wiem co tu sie dzieje wiec na razie nie ruszam
        List<Card>[] playersCards = { player0Cards, player1Cards };
        for (int i = 0; i < playersCards.Length; i++)
        {
            for (int j = 0; j < playersCards[i].Count; j++)
            {
                GameObject go = (GameObject)Resources.Load("prefabs/" + playersCards[i][j], typeof(GameObject));
                Card card = Instantiate(go, new Vector3(0, 0, 0), go.transform.rotation).GetComponent<Card>();
                card.PrepareForBattle(this, i);
            }
        }
    }

    private void SetDeaths(IEnumerable<Card> killedCards)
    {
        foreach(var card in killedCards)
        {
            card.Death();
        }
    }

    public void CheckDeaths()
    {
        //todo chodzilo o karty na stole?
        var currentUserKilledCards = CurrentPlayer.CardsPlaces[Place.Table].Where(c => c.health <= 0);
        var enemyUserKilledCards = EnemyUser.CardsPlaces[Place.Table].Where(c => c.health <= 0);

        SetDeaths(currentUserKilledCards);
        SetDeaths(enemyUserKilledCards);
        //for (int i = 0; i < 2; i++)
        //{
        //    for (int j = cards[i, 2].Count - 1; j >= 0; j--)
        //    {
        //        if (cards[i, 2][j].health <= 0)
        //            cards[i, 2][j].Death();
        //    }
        //}
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
        SelectedCard = null;
    }

    public void GiveTurn()
    {
        var newTurnCards = CurrentPlayer.CardsPlaces[Place.Table];
        foreach(var card in newTurnCards)
        {
            card.OnNewTurn();
        }
        //currentPlayer = OpposingPlayer();

        //for (int i = 0; i < cards[2, currentPlayer].Count; i++)
        //    cards[2, currentPlayer][i].OnNewTurn();

        CheckDeaths(); //Sprawdź czy ktoś umarł/przegrał.
    }

}
