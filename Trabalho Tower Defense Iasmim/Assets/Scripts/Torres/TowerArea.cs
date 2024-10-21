using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe respons�vel por verificar por meiop da tag Torre, se alguma torre est� dentro da �rea ou n�o.
public class TowerArea : MonoBehaviour
{
    public bool estaOcupado = false; //Vari�vel que armazena se o local est� ocupado ou n�o.

    //M�todo para quando o clique do mouse acontecer, a torre ser comprada e ser instanciada no bloco clicado.
    private void OnMouseDown()
    {
        if  (estaOcupado == false)
        {
            TowerPlace.instance.ComprarTorre(transform.position);
        }
    }

}
