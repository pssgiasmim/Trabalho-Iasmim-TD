using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTower : TowerBase
{
    //Método inicia a classe
    public void Start()
    {
       
    }

    //Método que faz a LightTower disparar três bombas contra os inimigos.
    public override void Atacar(EnemyBase enemiesInRange)
    {
        Debug.Log("Atacando com três bombas.");
         if (Time.time >= UltimoAtaque + TaxaDeAtaque)
         {
            int dano = Dano;

            DispararBomba(dano, enemiesInRange);
            
            UltimoAtaque = Time.time;
         }


        if (Time.time >= UltimoAtaque + TaxaDeAtaque)
        {
            int dano = Dano;

            DispararBomba(dano, enemiesInRange);

            UltimoAtaque = Time.time;
        }

        if (Time.time >= UltimoAtaque + TaxaDeAtaque)
        {
            int dano = Dano;

            DispararBomba(dano, enemiesInRange);

            UltimoAtaque = Time.time;
        }
    }


    
}
