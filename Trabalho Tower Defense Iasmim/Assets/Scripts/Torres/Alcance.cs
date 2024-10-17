using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe respons�vel pelo alcance das torres para que elas consigam atirar contra os inimigos.
public class Alcance : MonoBehaviour
{

     TowerBase torre; //

    /* M�todo que verifica se os inimigos est�o perto das torres.
     * Se o inimigo ter a tag inimigo, e ele estiver perto (on trigger)
     * A torre ataca.
     */

    private void Start()
    {
        torre = GetComponentInParent<TowerBase>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            torre.Atacar(other.gameObject);
        }
    }

    //M�todo que verifica se os inimigos est�o longe da torre.
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {

        }
    }
}
