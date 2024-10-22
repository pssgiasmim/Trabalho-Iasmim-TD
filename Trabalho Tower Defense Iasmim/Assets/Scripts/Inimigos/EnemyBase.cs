using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe Base dos inimigos. Todos os cinco inimigos herdam desta classe. Eles recebm dano e se destroem. Eles atacam. São instanciados numa direção e verifica se eles passaram das torres.
public class EnemyBase : MonoBehaviour, IAtacavel
{
    public int saude; //Variável que representa a quantidade de vida do inimigo.
    public string tipoDeInimigo; //Variável que vê qual é o tipo de inimigo.

    [SerializeField] float speed; //Variável que é a velocidade dos inimigos.
    [SerializeField] Rigidbody2D rigidbody2D; //Variável que cuida da fisica dos inimigos.
    [SerializeField] int dano = 10; //Dano que o inimigo causará nas torres.



    // Método chamado quando o inimigo receber dano.
    public void ReceberDano(int quantidade)
    {
        saude -= quantidade; 

        
        if (saude <= 0)
        {
            Morrer(); 
        }
    }



    //Método para destruir o inimigo
    public virtual void Morrer()
    {
        Destroy(gameObject); 

        GameManager.instance.enemies.Remove(gameObject);
    }



    //Método que faz os inimigos atacarem as torres.
    public virtual void Atacar(GameObject alvo)
    {
        TowerBase torre = alvo.GetComponent<TowerBase>(); //A variável torre do tipo TowerBase está recebendo a informação de que é o alvo dos inimigos.

        if (torre != null)
        {
            torre.ReceberDano(dano);

            Debug.Log(tipoDeInimigo + " atacou a torre e causou dano!");
        }

        if (torre.saudeDaTorre <= 0)
        {
            Debug.Log("Torre destruída!");

        }
    }



    // Método que verifica se os inimigos estão perto das torres.
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Torre"))
        {
            Atacar(other.gameObject);
        }
    }



    //Método que verifica se as torres estão longe dos inimigos.
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Torre"))
        {

        }
    }



    // Método que faz os inimigos se moverem no mapa.
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
