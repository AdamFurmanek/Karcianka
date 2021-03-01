using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

//Klasa gracza lub przeciwnika W WALCE.
//Zawiera talię kart DO WALKI jako obiekty klasy Card, informację o tym ile ma życia i many w walce.

//Po co w ogóle rozdzielić gracza na mapie i gracza w grze?
//Ponieważ gdyby tego nie odróżnić, wszystkie karty, wszystkich przeciwników i gracza musiałyby być wczytane na poczatku
//działania aplikacji, aż do jej końca.
//Rozdzielając to, instancjujemy tylko dwie talie kart w trakcie walki, które potem zostaną usunięte gdy wrócimy do mapy.
public class Player
{
    //Karty gracza, aktualnie w formie 4 list: stos, ręka, stół, cmentarz.
    public List<Card>[] cards = { new List<Card>(), new List<Card>(), new List<Card>(), new List<Card>()};

    public Player(Match match, Person person)
    {
        for (int i = 0; i < person.personCards.Count; i++) {
            GameObject go = (GameObject)Resources.Load("prefabs/" + person.personCards[i], typeof(GameObject));
            Card card = GameObject.Instantiate(go, new Vector3(0, 0, 0), go.transform.rotation).GetComponent<Card>();
            card.PrepareForBattle(match, this);
        }
    }
}

