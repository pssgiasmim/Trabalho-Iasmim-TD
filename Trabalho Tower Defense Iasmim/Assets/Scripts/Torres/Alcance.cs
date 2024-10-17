using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe responsável pelo alcance das torres para que elas consigam atirar contra os inimigos.
public class Alcance : MonoBehaviour
{

     TowerBase torre; //

    /* Método que verifica se os inimigos estão perto das torres.
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

    //Método que verifica se os inimigos estão longe da torre.
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {

        }
    }
}
