using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*A classe GameManager, gerencia tudo o que tem dentro do jogo. 
  Como, uma lista de inimigos na cena. */

public class GameManager : MonoBehaviour
{
    [SerializeField] List<TowerBase> LugarDasTorres = new List<TowerBase>(); //Lista das torres que são colocadas no mapa.
    [SerializeField] List<EnemyBase> enemies = new List<EnemyBase>(); //Lista dos inimigos que estão no mapa.

    [SerializeField] EnemyDark enemyDark; //Variável que será acrescentada na lista EnemyBase, que é o inimigo do escuro.
    [SerializeField] EnemyFire enemyFire; //Variável que será acrescentada na lista EnemyBase, que é o inimigo de fogo.
    [SerializeField] EnemyIce enemyIce; //Variável que será acrescentada na lista EnemyBase, que é o inimigo de gelo.
    [SerializeField] EnemyLight enemyLight; //Variável que será acrescentada na lista EnemyBase, que é o inimigo de luz.
    [SerializeField] EnemyRock enemyRock; //Variável que será acrescentada na lista EnemyBase, que é o inimigo de pedra.


    //Método que identifica qual inimigo a torre vai atacar
    public void Update()
    {
        GerenciarInimigo();

        foreach (TowerBase tower in LugarDasTorres)
        {
            
            List<EnemyBase> enemiesInRange = GetEnemiesInRange(tower);
            
            tower.Atacar(enemiesInRange);
        }
    }

    //Gerencia uma certa quantidade de inimigos na cena, não permintindo que passem de 10.
    public void GerenciarInimigo()
    {
        int inimigosAtivos = enemies.Count; //Variável que recebe como valor um contador de inimigos.

        while (inimigosAtivos < 10)
        {
            SpawnManager.instance.Spawn();
            inimigosAtivos++;

            AdicionarInimigos();
        }
    }

    //Método que adiciona os inimigos na lista
    public void AdicionarInimigos()
    {
        enemies.Add(enemyDark);
        enemies.Add(enemyFire);
        enemies.Add(enemyIce);
        enemies.Add(enemyLight);
        enemies.Add(enemyRock);
    }

    //Verifica se o inimigo em alcance, é do mesmo tipo do tipo que a torre ataca.
    List<EnemyBase>GetEnemiesInRange(TowerBase tower)
    {
        //Adicionando novos valores na lista de inimigos.
        List<EnemyBase> enemiesInRange = new List<EnemyBase>();

        
        foreach (EnemyBase enemy in enemies)
        {
            
            if (Vector3.Distance(tower.transform.position, enemy.transform.position) <= tower.Alcance) 
            {
                
                enemiesInRange.Add(enemy);
            }
        }

        
        return enemiesInRange;
    }

}
