using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

//Klasa gracza lub przeciwnika NA MAPIE
//Zawiera talię kart POZA WALKĄ w formie STRING, informację o tym ile ma życia i many ogólnie.
public class Person : MonoBehaviour
{
    public List<string> personCards = new List<string>();
    public bool computer;
    private float speed = 4;

    public Person()
    {
        //Włożenie przykładowych kart do testów (tymczasowo, to będzie robione gdzieś indziej).
        for(int i = 0; i < 10; i++)
            personCards.Add("Soldier");
    }

    public void Update()
    {
        if (!computer)
        {
            if (Input.GetKey(KeyCode.W))
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            else if (Input.GetKey(KeyCode.S))
                transform.Translate(Vector3.back * Time.deltaTime * speed);
            else if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            else if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (computer)
        {
            SceneManager.LoadScene("Match");
        }
    }
}
