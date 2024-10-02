using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //A classe GameManager, gerencia tudo o que tem dentro do jogo.

    [SerializeField] List<TowerBase> LugarDasTorres; //Lista das torres que s�o colocadas no mapa.
    [SerializeField] List<EnemyBase> enemies; //Lista dos inimigos que est�o no mapa.

    [SerializeField] FireTower fireTower; //Vari�vel que referencia a Torre de Fogo.
    [SerializeField] IceTower iceTower; //Vari�vel que referencia a Torre de Gelo.
    [SerializeField] LightTower lightTower; //Vari�vel que referencia a Torre de Luz.

    [SerializeField] FireEnemy fireEnemy; //Vari�vel que refencia o Inimigo de Fogo.
    [SerializeField] IceEnemy iceEnemy; //Vari�vel que refencia o Inimigo de Gelo.
    [SerializeField] DarkEnemy darkEnemy; //Vari�vel que refencia o Inimigo de Escuro.
    [SerializeField] LightEnemy lightEnemy; //Vari�vel que refencia o Inimigo de Luz.
    [SerializeField] RockEnemy rockEnemy; //Vari�vel que refencia o Inimigo de Pedra.

    //M�todo que identifica qual inimigo a torre vai atacar
    public void Update()
    {
        //Para cada torre em Lugar das Torres
        foreach (TowerBase tower in LugarDasTorres)
        {
            //Acessar a lsta de inimigos  e  "comparar" se o tipo dele � igual ao tipo que a torre ataca.
            List<EnemyBase> enemiesInRange = GetEnemiesInRange(tower);
            tower.Atacar(enemiesInRange);
        }
    }


}
