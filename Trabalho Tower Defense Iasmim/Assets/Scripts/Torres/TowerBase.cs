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

    
    //M�todo que tem como fun��o atacar os inimigos.
    public virtual void Atacar(List<EnemyBase> enemiesInRange)
    {
        if (Time.time >= UltimoAtaque + TaxaDeAtaque)
        {
            foreach (EnemyBase enemy in enemiesInRange)
            {
                int dano = Dano; //Vari�vel dano que recebe o valor de Dano.

                if (enemy.tipoDeInimigo == "Dark" && this is FireTower)
                {
                    dano *= 2;
                }

                else if (enemy.tipoDeInimigo == "Fire" && this is IceTower)
                {
                    dano *= 2;
                }

                else
                {
                    dano = 1;
                }

                DispararBola(dano, enemy);

                break;
            }

            UltimoAtaque = Time.time;
        }
    }
}
