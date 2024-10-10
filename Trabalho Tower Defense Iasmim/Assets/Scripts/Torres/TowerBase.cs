using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta classe serve de base para todas as outras torres.

public class TowerBase : MonoBehaviour, IAtacavel
{
    public float TaxaDeAtaque; //Variável da Taxa de ataque da torre.
    public float Alcance; //Variável de Alcance da torre.
    public int Dano; //Variável de Dano da torre.
    public string TipoDeDano; //Variável do Tipo de dano da torre.
    public float UltimoAtaque; //Variável que registra o último ataque da torre.
    public GameObject bombaPrefab; //Variável do prefab da bomba.
    public Transform pontoDeTiro; //Variável do ponto de onde a bomba vai ser disparada.

    
    //Método que tem como função atacar os inimigos.
    public virtual void Atacar(List<EnemyBase> enemiesInRange)
    {
        if (Time.time >= UltimoAtaque + TaxaDeAtaque)
        {
            foreach (EnemyBase enemy in enemiesInRange)
            {
                int dano = Dano; //Variável dano que recebe o valor de Dano.

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

                DispararBomba(dano, enemy);

                break;
            }

            UltimoAtaque = Time.time;
        }
    }

    //Método para fazer a torre disparar a bomba.
    void DispararBomba(int dano, EnemyBase enemy)
    {
        GameObject bomba = Instantiate(bombaPrefab, pontoDeTiro.position, Quaternion.identity); //Variável da bomba que recebe o instanciamente do prefab da bomba.

        Bomba.bombaScript = bomba.GetComponent<Bomba>();

        bombaScript.SetDano(dano);

        bombaScript.SetTarget(enemy.GameObject);
    }
}
