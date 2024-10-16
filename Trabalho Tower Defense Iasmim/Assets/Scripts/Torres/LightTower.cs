using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTower : TowerBase
{
    //Método inicia a classe
    public void Start()
    {
       
    }

    //Método
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
