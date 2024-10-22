using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe responsável pelo alcance das torres para que elas consigam atirar contra os inimigos.
public class Alcance : MonoBehaviour
{

     TowerBase torre; //Variável do tipo TowerBase.

    //Método que 
    private void Start()
    {
        torre = GetComponentInParent<TowerBase>();
    }

    // Método que verifica se os inimigos estão perto das torres.   
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
