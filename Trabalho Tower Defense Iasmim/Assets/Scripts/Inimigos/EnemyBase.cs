using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IAtacavel
{
    //Classe representante dos inimigos.

    public int saude; //Variável que "conta" a vida do inimigo.
    public string tipoDeInimigo; //Variável que vê qual é o tipo de inimigo.

    //Método chamado quando o inimigo receber dano.
    public void ReceberDano(int quantidade)
    {
        saude -= quantidade; //saude inicia sendo menor ou igual a quantidade.

        //Se saude for menor ou igual a zero, então
        if (saude <= 0)
        {
            Morrer(); //chamando o método morrer.
        }
    }

    //Método para destruir o inimigo
    public void Morrer()
    {
        Destroy(gameObject); //Aqui o inimigo será removido
    }

    public virtual void Atacar()
    {
        gameObject.SetActive(false);
    }
        
}
