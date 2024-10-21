using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe responsável por verificar por meiop da tag Torre, se alguma torre está dentro da área ou não.
public class TowerArea : MonoBehaviour
{
    public bool estaOcupado = false; //Variável que armazena se o local está ocupado ou não.

    //Método para quando o clique do mouse acontecer, a torre ser comprada e ser instanciada no bloco clicado.
    private void OnMouseDown()
    {
        if  (estaOcupado == false)
        {
            TowerPlace.instance.ComprarTorre(transform.position);
        }
    }

}
