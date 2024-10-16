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
    public float TaxaDeAtaque; //Variável da Taxa de ataque da torre.
    public float Alcance; //Variável de Alcance da torre.
    public int Dano; //Variável de Dano da torre.
    public string TipoDeDano; //Variável do Tipo de dano da torre.
    public float UltimoAtaque; //Variável que registra o último ataque da torre.
    public GameObject bombaPrefab; //Variável do prefab da bomba.
    public Transform pontoDeTiro; //Variável do ponto de onde a bomba vai ser disparada.

    

    /* Método que verifica se os inimigos estão perto das torres.
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

    //Método que verifica se os inimigos estão longe da torre.
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {

        }
    }

    /* Método que tem como função atacar os inimigos.
     * verifica o tempo do último ataque com Time.time.
     * dano recebe Dano.
     * se o inimigo for do tipo dark e a torre for uma fire tower, ele recebe dano dobrado. Assim continua...
     * a variável UltimoAtaque recebe o Time.time atual.
     */
    public virtual void Atacar(EnemyBase enemiesInRange)
    {
       
        if (Time.time >= UltimoAtaque + TaxaDeAtaque)
        {
            
            
                int dano = Dano; //Variável dano que recebe o valor de Dano.

                if (enemiesInRange.tipoDeInimigo== "Dark" && this is FireTower)
                {
                    dano *= 2;
                }

                else if (enemiesInRange.tipoDeInimigo == "Fire" && this is IceTower)
                {
                    dano *= 2;
                }

                else
                {
                    dano = 1;
                }

                DispararBomba(dano, enemiesInRange);

                
            

            UltimoAtaque = Time.time;
        }
    }

    /* Método para fazer a torre disparar a bomba.
     * variável da bomba que recebe o instanciamente do prefab da bomba.
     * a bomba do bombaScript vai receber o componente da bomba.
     * chama o método DefinirDano da bomba e o método DefinirAlvo.
    */
    void DispararBomba(int dano, EnemyBase enemy)
    {
        GameObject bomba = Instantiate(bombaPrefab, pontoDeTiro.position, Quaternion.identity); //Variável da bomba que recebe o instanciamente do prefab da bomba.

        Bomba bombaScript = bomba.GetComponent<Bomba>();

        bombaScript.DefinirDano(dano);

        bombaScript.DefinirAlvo(enemy.gameObject);
    }
}
