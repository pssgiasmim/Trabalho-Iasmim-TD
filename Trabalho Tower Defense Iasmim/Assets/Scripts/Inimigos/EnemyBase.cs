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
    public int saude; //Vari�vel que "conta" a vida do inimigo.
    public string tipoDeInimigo; //Vari�vel que v� qual � o tipo de inimigo.

    [SerializeField] float speed; //Vari�vel que � a velocidade dos inimigos.
    [SerializeField] Rigidbody2D rigidbody2D; //Vari�vel que cuida da fisica dos inimigos.

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
    public void Morrer()
    {
        Destroy(gameObject); 
    }

    //M�todo que faz os inimigos atacarem as torres, est� inativo.
    public virtual void Atacar(EnemyBase enemiesInRange)
    {
        gameObject.SetActive(false);
    }

    /* M�todo que faz os inimigos se moverem no mapa.
     * Pega a velocidade do rigidbody do inimigo e faz ele se mover para o lado esquerdo (-1) sem mexer na altura (0).
     */
    public void Update()
    {
        rigidbody2D.velocity = new Vector2(-1, 0);
    }

}
