using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta classe serve de base para todas as outras torres.

public class TowerBase : MonoBehaviour, IAtacavel
{
    public float TaxaDeAtaque; //Vari�vel da Taxa de ataque da torre.
    public float Alcance; //Vari�vel de Alcance da torre.
    public int Dano; //Vari�vel de Dano da torre.
    public string TipoDeDano; //Vari�vel do Tipo de dano da torre.
    public float UltimoAtaque; //Vari�vel que registra o �ltimo ataque da torre.
    public GameObject bombaPrefab; //Vari�vel do prefab da bomba.
    public Transform pontoDeTiro; //Vari�vel do ponto de onde a bomba vai ser disparada.

    

    //M�todo que verifica se os inimigos est�o perto das torres
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            Atacar(other.GetComponent<EnemyBase>());
        }
    }

    //M�todo que verifica se os inimigos est�o longe da torre
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {

        }
    }

    //M�todo que tem como fun��o atacar os inimigos.
    public virtual void Atacar(EnemyBase enemiesInRange)
    {
       
        if (Time.time >= UltimoAtaque + TaxaDeAtaque)
        {
            
            
                int dano = Dano; //Vari�vel dano que recebe o valor de Dano.

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

    //M�todo para fazer a torre disparar a bomba.
    void DispararBomba(int dano, EnemyBase enemy)
    {
        GameObject bomba = Instantiate(bombaPrefab, pontoDeTiro.position, Quaternion.identity); //Vari�vel da bomba que recebe o instanciamente do prefab da bomba.

        Bomba bombaScript = bomba.GetComponent<Bomba>();

        bombaScript.DefinirDano(dano);

        bombaScript.DefinirAlvo(enemy.gameObject);
    }
}
