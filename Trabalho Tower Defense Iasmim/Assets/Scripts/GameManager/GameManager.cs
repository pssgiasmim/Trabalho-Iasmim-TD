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

    [SerializeField] EnemyFire enemyFire; //Vari�vel que refencia o Inimigo de Fogo.
    [SerializeField] EnemyIce enemyIce; //Vari�vel que refencia o Inimigo de Gelo.
    [SerializeField] EnemyDark enemyDark; //Vari�vel que refencia o Inimigo de Escuro.
    [SerializeField] EnemyLight enemyLight; //Vari�vel que refencia o Inimigo de Luz.
    [SerializeField] EnemyRock enemyRock; //Vari�vel que refencia o Inimigo de Pedra.

    //M�todo que identifica qual inimigo a torre vai atacar
    public void Update()
    {
        //Para cada torre em Lugar das Torres
        foreach (TowerBase tower in LugarDasTorres)
        {
            //Acessar a lista de inimigos  e  "comparar" se o tipo dele � igual ao tipo que a torre ataca.
            List<EnemyBase> enemiesInRange = GetEnemiesInRange(tower);
            //atacar o inimigo
            tower.Atacar(enemiesInRange);
        }
    }

    //Verifica se o inimigo em alcance, � do mesmo tipo do tipo que a torre ataca.
    List<EnemyBase>GetEnemiesInRange(TowerBase tower)
    {
        //Adicionando novos valores na lista de inimigos.
        List<EnemyBase> enemiesInRange = new List<EnemyBase>();

        //Para cada inimigo em inimigos
        foreach (EnemyBase enemy in enemies)
        {
            //Se a distancia de Vector3 que � a posi��o da torre e a posi��o do inimigo for menor ou igual a dano;
            if (Vector3.Distance(tower.transform.position, enemy.transform.position) <= tower.Alcance) 
            {
                //Ent�o adcionada inimigos no alcance na lista inimigo
                enemiesInRange.Add(enemy);
            }
        }

        //retornando os inimigos em alcance
        return enemiesInRange;
    }

}
