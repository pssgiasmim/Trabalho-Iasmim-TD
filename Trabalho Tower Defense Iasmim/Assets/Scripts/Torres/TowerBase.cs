using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Esta classe serve de base para todas as outras torres.
 * A torre recebe dano do inimigo.
 * A torre pode ser destr�da pelo inimigo.
 * Ataque aos inimigos -> Nas subclasses est� definido o ataque.
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
