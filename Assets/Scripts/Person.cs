using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Klasa gracza lub przeciwnika NA MAPIE
//Zawiera talię kart POZA WALKĄ w formie STRING, informację o tym ile ma życia i many ogólnie.
public class Person
{
    public List<string> personCards = new List<string>();

    public Person()
    {
        //Włożenie przykładowych kart do testów (tymczasowo, to będzie robione gdzieś indziej).
        for(int i = 0; i < 10; i++)
            personCards.Add("Soldier");
    }
}
