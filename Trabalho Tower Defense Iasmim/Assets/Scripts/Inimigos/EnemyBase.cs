using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe Base dos inimigos. Todos os cinco inimigos herdam desta classe. Eles recebm dano e se destroem. Eles atacam. S�o instanciados numa dire��o e verifica se eles passaram das torres.
public class EnemyBase : MonoBehaviour, IAtacavel
{
    public int saude; //Vari�vel que representa a quantidade de vida do inimigo.
    public string tipoDeInimigo; //Vari�vel que v� qual � o tipo de inimigo.

    [SerializeField] float speed; //Vari�vel que � a velocidade dos inimigos.
    [SerializeField] Rigidbody2D rigidbody2D; //Vari�vel que cuida da fisica dos inimigos.
    [SerializeField] int dano = 10; //Dano que o inimigo causar� nas torres.



    // M�todo chamado quando o inimigo receber dano.
    public void ReceberDano(int quantidade)
    {
        saude -= quantidade; 

        
        if (saude <= 0)
        {
            Morrer(); 
        }
    }



    //M�todo para destruir o inimigo
    public virtual void Morrer()
    {
        Destroy(gameObject); 

        GameManager.instance.enemies.Remove(gameObject);
    }



    //M�todo que faz os inimigos atacarem as torres.
    public virtual void Atacar(GameObject alvo)
    {
        TowerBase torre = alvo.GetComponent<TowerBase>(); //A vari�vel torre do tipo TowerBase est� recebendo a informa��o de que � o alvo dos inimigos.

        if (torre != null)
        {
            torre.ReceberDano(dano);

            Debug.Log(tipoDeInimigo + " atacou a torre e causou dano!");
        }

        if (torre.saudeDaTorre <= 0)
        {
            Debug.Log("Torre destru�da!");

        }
    }



    // M�todo que verifica se os inimigos est�o perto das torres.
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Torre"))
        {
            Atacar(other.gameObject);
        }
    }



    //M�todo que verifica se as torres est�o longe dos inimigos.
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Torre"))
        {

        }
    }



    // M�todo que faz os inimigos se moverem no mapa.
    public virtual void Update()
    {
        rigidbody2D.velocity = new Vector2(-1, 0);

        if (transform.position.x < GameManager.instance.screenBounds.x * -1)
        {
            GameManager.instance.inimigosQuePassaram++;
            GameManager.instance.InimigoPassou();
            Morrer();
        }

        
    }

}
