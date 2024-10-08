using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe Base dos inimigos. Todos os cinco inimigos herdam desta classe.

public class EnemyBase : MonoBehaviour, IAtacavel
{
    public int saude; //Vari�vel que "conta" a vida do inimigo.
    public string tipoDeInimigo; //Vari�vel que v� qual � o tipo de inimigo.

    [SerializeField] float speed; //Vari�vel que � a velocidade dos inimigos.
    [SerializeField] Rigidbody2D rigidbody2D; //Vari�vel que cuida da fisica dos inimigos.

    //M�todo chamado quando o inimigo receber dano.
    public void ReceberDano(int quantidade)
    {
        saude -= quantidade; 

        
        if (saude <= 0)
        {
            Morrer(); 
        }
    }

    //M�todo para destruir o inimigo
    public void Morrer()
    {
        Destroy(gameObject); 
    }

    //M�todo que faz os inimigos atacarem as torres.
    public virtual void Atacar(List<EnemyBase> enemiesInRange)
    {
        gameObject.SetActive(false);
    }

    //M�todo que faz os inimigos se moverem no mapa.
    public void Update()
    {
        rigidbody2D.velocity = new Vector2(-1, 0);
    }

}
