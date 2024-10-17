using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTower : TowerBase
{
    //M�todo inicia a classe
    public void Start()
    {
       
    }

    //M�todo que faz a LightTower disparar tr�s bombas contra os inimigos.
    public override void Atacar(EnemyBase enemiesInRange)
    {
        Debug.Log("Atacando com tr�s bombas.");
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
