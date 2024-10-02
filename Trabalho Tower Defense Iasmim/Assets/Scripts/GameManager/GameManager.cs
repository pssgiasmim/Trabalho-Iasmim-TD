using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //A classe GameManager, gerencia tudo o que tem dentro do jogo.

    [SerializeField] List<TowerBase> LugarDasTorres; //Lista das torres que são colocadas no mapa.
    [SerializeField] List<EnemyBase> enemies; //Lista dos inimigos que estão no mapa.

    [SerializeField] FireTower fireTower; //Variável que referencia a Torre de Fogo.
    [SerializeField] IceTower iceTower; //Variável que referencia a Torre de Gelo.
    [SerializeField] LightTower lightTower; //Variável que referencia a Torre de Luz.

    [SerializeField] FireEnemy fireEnemy; //Variável que refencia o Inimigo de Fogo.
    [SerializeField] IceEnemy iceEnemy; //Variável que refencia o Inimigo de Gelo.
    [SerializeField] DarkEnemy darkEnemy; //Variável que refencia o Inimigo de Escuro.
    [SerializeField] LightEnemy lightEnemy; //Variável que refencia o Inimigo de Luz.
    [SerializeField] RockEnemy rockEnemy; //Variável que refencia o Inimigo de Pedra.

    //Método que identifica qual inimigo a torre vai atacar
    public void Update()
    {
        //Para cada torre em Lugar das Torres
        foreach (TowerBase tower in LugarDasTorres)
        {
            //Acessar a lsta de inimigos  e  "comparar" se o tipo dele é igual ao tipo que a torre ataca.
            List<EnemyBase> enemiesInRange = GetEnemiesInRange(tower);
            tower.Atacar(enemiesInRange);
        }
    }


}
