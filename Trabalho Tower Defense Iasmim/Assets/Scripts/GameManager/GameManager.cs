using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*A classe GameManager, gerencia tudo o que tem dentro do jogo. 
  Como, uma lista de inimigos na cena. */

public class GameManager : MonoBehaviour
{
    [SerializeField] List<TowerBase> LugarDasTorres; //Lista das torres que são colocadas no mapa.
    [SerializeField] List<EnemyBase> enemies; //Lista dos inimigos que estão no mapa.


    //Método que identifica qual inimigo a torre vai atacar
    public void Update()
    {
       
        foreach (TowerBase tower in LugarDasTorres)
        {
            
            List<EnemyBase> enemiesInRange = GetEnemiesInRange(tower);
            
            tower.Atacar(enemiesInRange);
        }
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
