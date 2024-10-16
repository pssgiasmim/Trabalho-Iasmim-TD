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
    public float TaxaDeAtaque; //Vari�vel da Taxa de ataque da torre.
    public float Alcance; //Vari�vel de Alcance da torre.
    public int Dano; //Vari�vel de Dano da torre.
    public string TipoDeDano; //Vari�vel do Tipo de dano da torre.
    public float UltimoAtaque; //Vari�vel que registra o �ltimo ataque da torre.
    public GameObject bombaPrefab; //Vari�vel do prefab da bomba.
    public Transform pontoDeTiro; //Vari�vel do ponto de onde a bomba vai ser disparada.

    

    /* M�todo que verifica se os inimigos est�o perto das torres.
     * Se o inimigo ter a tag inimigo, e ele estiver perto (on trigger)
     * A torre ataca.
     */
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            Atacar(other.GetComponent<EnemyBase>());
        }
    }

    //M�todo que verifica se os inimigos est�o longe da torre.
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {

        }
    }

    // M�todo que tem como fun��o atacar os inimigos.
    public virtual void Atacar(EnemyBase enemiesInRange)
    {
       
        
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
        
    
}
