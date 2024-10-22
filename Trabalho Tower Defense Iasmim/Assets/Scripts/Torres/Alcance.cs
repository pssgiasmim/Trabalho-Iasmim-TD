using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe respons�vel pelo alcance das torres para que elas consigam atirar contra os inimigos.
public class Alcance : MonoBehaviour
{

     TowerBase torre; //Vari�vel do tipo TowerBase.

    //M�todo que 
    private void Start()
    {
        torre = GetComponentInParent<TowerBase>();
    }

    // M�todo que verifica se os inimigos est�o perto das torres.   
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
