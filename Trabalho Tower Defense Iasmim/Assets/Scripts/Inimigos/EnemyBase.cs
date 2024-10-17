using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Classe Base dos inimigos. Todos os cinco inimigos herdam desta classe.
 * Aqui n�s fazemos os inimigos receberem o dano.
 * Ap�s receber o dano, eles s�o destruidos / morrem.
 * M�todo que faz os inimigos atacarem , esta inativo.
 * M�todo update que faz o inimigo vir numa velocidade e consequentemente ser instanciado na cena.
 */

public class EnemyBase : MonoBehaviour, IAtacavel
{
    public int saude; //Vari�vel que representa a quantidade de vida do inimigo.
    public string tipoDeInimigo; //Vari�vel que v� qual � o tipo de inimigo.

    [SerializeField] float speed; //Vari�vel que � a velocidade dos inimigos.
    [SerializeField] Rigidbody2D rigidbody2D; //Vari�vel que cuida da fisica dos inimigos.
    [SerializeField] int dano = 10; //Dano que o inimigo causar� nas torres.

    /* M�todo chamado quando o inimigo receber dano.
     * Ele subtrai a "saude" do inimigo pela "quantidade" de dano recebido.
     * verifica se a "saude" � menor do que 0 para destruir o inimigo com o m�todo "Morrer()".
     */
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

    /* M�todo que verifica se os inimigos est�o perto das torres.
     * Se a torre ter a tag Torre, e ele estiver perto (on trigger), o  inimigo vai causar dano.
     */
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

    /* M�todo que faz os inimigos se moverem no mapa.
     * Pega a velocidade do rigidbody do inimigo e faz ele se mover para o lado esquerdo (-1) sem mexer na altura (0).
     */
    public void Update()
    {
        rigidbody2D.velocity = new Vector2(-1, 0);
    }

}
