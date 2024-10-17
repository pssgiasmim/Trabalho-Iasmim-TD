using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Classe Base dos inimigos. Todos os cinco inimigos herdam desta classe.
 * Aqui nós fazemos os inimigos receberem o dano.
 * Após receber o dano, eles são destruidos / morrem.
 * Método que faz os inimigos atacarem , esta inativo.
 * Método update que faz o inimigo vir numa velocidade e consequentemente ser instanciado na cena.
 */

public class EnemyBase : MonoBehaviour, IAtacavel
{
    public int saude; //Variável que representa a quantidade de vida do inimigo.
    public string tipoDeInimigo; //Variável que vê qual é o tipo de inimigo.

    [SerializeField] float speed; //Variável que é a velocidade dos inimigos.
    [SerializeField] Rigidbody2D rigidbody2D; //Variável que cuida da fisica dos inimigos.
    [SerializeField] int dano = 10; //Dano que o inimigo causará nas torres.

    /* Método chamado quando o inimigo receber dano.
     * Ele subtrai a "saude" do inimigo pela "quantidade" de dano recebido.
     * verifica se a "saude" é menor do que 0 para destruir o inimigo com o método "Morrer()".
     */
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

    /* Método que verifica se os inimigos estão perto das torres.
     * Se a torre ter a tag Torre, e ele estiver perto (on trigger), o  inimigo vai causar dano.
     */
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

    /* Método que faz os inimigos se moverem no mapa.
     * Pega a velocidade do rigidbody do inimigo e faz ele se mover para o lado esquerdo (-1) sem mexer na altura (0).
     */
    public void Update()
    {
        rigidbody2D.velocity = new Vector2(-1, 0);
    }

}
