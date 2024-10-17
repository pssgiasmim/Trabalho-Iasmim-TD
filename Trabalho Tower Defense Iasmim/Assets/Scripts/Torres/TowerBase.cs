using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Esta classe serve de base para todas as outras torres.
 * Verificação de se há inimigos perto da torre para atacar.
 * Verificação para caso o inimigo saia de perto da torre.
 * Ataque aos inimigos.
 * Disparo da bomba.
 */

public class TowerBase : MonoBehaviour, IAtacavel
{
    public float taxaDeAtaque; //Variável da Taxa de ataque da torre.
    public float alcance; //Variável de Alcance da torre.
    public int Dano; //Variável de Dano da torre.
    public string tipoDeDano; //Variável do Tipo de dano da torre.
    public float ultimoAtaque; //Variável que registra o último ataque da torre.
    public GameObject bombaPrefab; //Variável do prefab da bomba.
    public Transform pontoDeTiro; //Variável do ponto de onde a bomba vai ser disparada.
    public int saudeDaTorre; //Variável que representa a saude da torre.
    

    /* Método que verifica se os inimigos estão perto das torres.
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

    //Método que verifica se os inimigos estão longe da torre.
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {

        }
    }

    //Método que faz a torre receber dano dos inimigos
    public void ReceberDano(int quantidade)
    {
        saudeDaTorre -= quantidade;

        if (saudeDaTorre <= 0)
        {
            DestruirTorre();
        }
    }

    //Método que destroi a torre com base nos danos jogados pelos inimigos.
    private void DestruirTorre()
    {
        Destroy(gameObject);
    }


    /* Método para fazer a torre disparar a bomba.
     * variável da bomba que recebe o instanciamente do prefab da bomba.
     * a bomba do bombaScript vai receber o componente da bomba.
     * chama o método DefinirDano da bomba e o método DefinirAlvo.
    */
    public void DispararBomba(int dano, EnemyBase enemy)
    {
        GameObject bomba = Instantiate(bombaPrefab, pontoDeTiro.position, Quaternion.identity); //Variável da bomba que recebe o instanciamente do prefab da bomba.

        Bomba bombaScript = bomba.GetComponent<Bomba>();

        bombaScript.DefinirDano(dano);

        bombaScript.DefinirAlvo(enemy.gameObject);
    }

    // Método que tem como função atacar os inimigos.
    public virtual void Atacar(GameObject alvo)
    {


    }
}
