using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe responsável por verificar por meiop da tag Torre, se alguma torre está dentro da área ou não.
public class TowerArea : MonoBehaviour
{
    public bool estaOcupado = false; //Variável que armazena se o local está ocupado ou não.

    //Método que verifica de a torre está dentro da área, utilizando uma tag Torre, que serve como "verificação".
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Torre"))
        {
            estaOcupado=true;
        }
    }

    //Método que verifica se a torre ainda está na área ou não.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Torre"))
        {
            estaOcupado = false;
        }
    }

}
