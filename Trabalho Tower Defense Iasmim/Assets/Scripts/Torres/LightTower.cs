using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTower : TowerBase
{
    //M�todo inicia a classe
    public void Start()
    {
       
    }

    //M�todo
    public override void Atacar(EnemyBase enemiesInRange)
    {
         if (Time.time >= UltimoAtaque + TaxaDeAtaque)
         {
            int dano = Dano;
            DispararBomba(dano, enemiesInRange);
            DispararBomba(dano, enemiesInRange);
            DispararBomba(dano, enemiesInRange);
            UltimoAtaque = Time.time;
         }
    }


    
}
