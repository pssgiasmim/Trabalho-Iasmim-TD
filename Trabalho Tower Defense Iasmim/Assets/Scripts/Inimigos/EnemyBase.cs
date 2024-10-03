using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IAtacavel
{
    //Classe representante dos inimigos.

    public int saude; //Vari�vel que "conta" a vida do inimigo.
    public string tipoDeInimigo; //Vari�vel que v� qual � o tipo de inimigo.

    //M�todo chamado quando o inimigo receber dano.
    public void ReceberDano(int quantidade)
    {
        saude -= quantidade; //saude inicia sendo menor ou igual a quantidade.

        //Se saude for menor ou igual a zero, ent�o
        if (saude <= 0)
        {
            Morrer(); //chamando o m�todo morrer.
        }
    }

    //M�todo para destruir o inimigo
    public void Morrer()
    {
        Destroy(gameObject); //Aqui o inimigo ser� removido
    }

    public virtual void Atacar()
    {
        gameObject.SetActive(false);
    }
        
}
