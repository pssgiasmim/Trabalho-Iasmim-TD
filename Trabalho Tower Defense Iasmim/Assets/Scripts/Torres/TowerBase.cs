using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Esta classe serve de base para todas as outras torres.
 * Verifica��o de se h� inimigos perto da torre para atacar.
 * Verifica��o para caso o inimigo saia de perto da torre.
 * Ataque aos inimigos.
 * Disparo da bomba.
 */

public class TowerBase : MonoBehaviour, IAtacavel
{
    public float taxaDeAtaque; //Vari�vel da Taxa de ataque da torre.
    public float alcance; //Vari�vel de Alcance da torre.
    public int Dano; //Vari�vel de Dano da torre.
    public string tipoDeDano; //Vari�vel do Tipo de dano da torre.
    public float ultimoAtaque; //Vari�vel que registra o �ltimo ataque da torre.
    public GameObject bombaPrefab; //Vari�vel do prefab da bomba.
    public Transform pontoDeTiro; //Vari�vel do ponto de onde a bomba vai ser disparada.
    public int saudeDaTorre; //Vari�vel que representa a saude da torre.
    

    /* M�todo que verifica se os inimigos est�o perto das torres.
     * Se o inimigo ter a tag inimigo, e ele estiver perto (on trigger)
     * A torre ataca.
     */
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            Atacar(other.gameObject);
        }
    }

    //M�todo que verifica se os inimigos est�o longe da torre.
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {

        }
    }

    //M�todo que faz a torre receber dano dos inimigos
    public void ReceberDano(int quantidade)
    {
        saudeDaTorre -= quantidade;

        if (saudeDaTorre <= 0)
        {
            DestruirTorre();
        }
    }

    //M�todo que destroi a torre com base nos danos jogados pelos inimigos.
    private void DestruirTorre()
    {
        Destroy(gameObject);
    }


    /* M�todo para fazer a torre disparar a bomba.
     * vari�vel da bomba que recebe o instanciamente do prefab da bomba.
     * a bomba do bombaScript vai receber o componente da bomba.
     * chama o m�todo DefinirDano da bomba e o m�todo DefinirAlvo.
    */
    public void DispararBomba(int dano, EnemyBase enemy)
    {
        GameObject bomba = Instantiate(bombaPrefab, pontoDeTiro.position, Quaternion.identity); //Vari�vel da bomba que recebe o instanciamente do prefab da bomba.

        Bomba bombaScript = bomba.GetComponent<Bomba>();

        bombaScript.DefinirDano(dano);

        bombaScript.DefinirAlvo(enemy.gameObject);
    }

    // M�todo que tem como fun��o atacar os inimigos.
    public virtual void Atacar(GameObject alvo)
    {


    }
}
