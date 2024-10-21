using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe respons�vel por verificar por meiop da tag Torre, se alguma torre est� dentro da �rea ou n�o.
public class TowerArea : MonoBehaviour
{
    public bool estaOcupado = false; //Vari�vel que armazena se o local est� ocupado ou n�o.

    //M�todo que verifica de a torre est� dentro da �rea, utilizando uma tag Torre, que serve como "verifica��o".
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Torre"))
        {
            estaOcupado=true;
        }
    }

    //M�todo que verifica se a torre ainda est� na �rea ou n�o.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Torre"))
        {
            estaOcupado = false;
        }
    }

}
