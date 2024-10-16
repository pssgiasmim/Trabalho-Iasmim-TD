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
    public int saude; //Variável que "conta" a vida do inimigo.
    public string tipoDeInimigo; //Variável que vê qual é o tipo de inimigo.

    [SerializeField] float speed; //Variável que é a velocidade dos inimigos.
    [SerializeField] Rigidbody2D rigidbody2D; //Variável que cuida da fisica dos inimigos.

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
    public void Morrer()
    {
        Destroy(gameObject); 
    }

    //Método que faz os inimigos atacarem as torres, está inativo.
    public virtual void Atacar(EnemyBase enemiesInRange)
    {
        gameObject.SetActive(false);
    }

    /* Método que faz os inimigos se moverem no mapa.
     * Pega a velocidade do rigidbody do inimigo e faz ele se mover para o lado esquerdo (-1) sem mexer na altura (0).
     */
    public void Update()
    {
        rigidbody2D.velocity = new Vector2(-1, 0);
    }

}
