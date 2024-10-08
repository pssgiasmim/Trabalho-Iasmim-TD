using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe Base dos inimigos. Todos os cinco inimigos herdam desta classe.

public class EnemyBase : MonoBehaviour, IAtacavel
{
    public int saude; //Variável que "conta" a vida do inimigo.
    public string tipoDeInimigo; //Variável que vê qual é o tipo de inimigo.

    [SerializeField] float speed; //Variável que é a velocidade dos inimigos.
    [SerializeField] Rigidbody2D rigidbody2D; //Variável que cuida da fisica dos inimigos.

    //Método chamado quando o inimigo receber dano.
    public void ReceberDano(int quantidade)
    {
        saude -= quantidade; 

        
        if (saude <= 0)
        {
            Morrer(); 
        }
    }

    //Método para destruir o inimigo
    public void Morrer()
    {
        Destroy(gameObject); 
    }

    //Método que faz os inimigos atacarem as torres.
    public virtual void Atacar(List<EnemyBase> enemiesInRange)
    {
        gameObject.SetActive(false);
    }

    //Método que faz os inimigos se moverem no mapa.
    public void Update()
    {
        rigidbody2D.velocity = new Vector2(-1, 0);
    }

}
