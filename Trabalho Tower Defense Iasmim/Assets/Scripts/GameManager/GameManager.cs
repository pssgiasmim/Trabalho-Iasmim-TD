using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*A classe GameManager, gerencia tudo o que tem dentro do jogo. 
  Como, uma lista de inimigos na cena. */

public class GameManager : MonoBehaviour
{
    [SerializeField] List<TowerBase> LugarDasTorres = new List<TowerBase>(); //Lista das torres que são colocadas no mapa.
    [SerializeField] List<GameObject> enemies = new List<GameObject>(); //Lista dos inimigos que estão no mapa.

    [SerializeField] EnemyDark enemyDark; //Variável que será acrescentada na lista EnemyBase, que é o inimigo do escuro.
    [SerializeField] EnemyFire enemyFire; //Variável que será acrescentada na lista EnemyBase, que é o inimigo de fogo.
    [SerializeField] EnemyIce enemyIce; //Variável que será acrescentada na lista EnemyBase, que é o inimigo de gelo.
    [SerializeField] EnemyLight enemyLight; //Variável que será acrescentada na lista EnemyBase, que é o inimigo de luz.
    [SerializeField] EnemyRock enemyRock; //Variável que será acrescentada na lista EnemyBase, que é o inimigo de pedra.

    //Singleton, que permite que todas as coisas públicas da classe sejam acessadas por outra classe.
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

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
        //int inimigosAtivos = enemies.Count; //Variável que recebe como valor um contador de inimigos.

        while (enemies.Count < 10)
        {
            SpawnManager.instance.Spawn();
            

           
        }
    }

    //Método que adiciona os inimigos na lista
    public void AdicionarInimigos(GameObject obj)
    {
        enemies.Add(obj);
        
    }

    //Verifica se o inimigo em alcance, é do mesmo tipo do tipo que a torre ataca.
    List<EnemyBase>GetEnemiesInRange(TowerBase tower)
    {
        //Adicionando novos valores na lista de inimigos.
        List<EnemyBase> enemiesInRange = new List<EnemyBase>();

        
        foreach (GameObject enemy in enemies)
        {
            
            if (Vector3.Distance(tower.transform.position, enemy.transform.position) <= tower.Alcance) 
            {
                
                //enemiesInRange.Add(enemy);
            }
        }

        
        return enemiesInRange;
    }

}
