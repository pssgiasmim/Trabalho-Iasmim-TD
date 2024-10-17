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
         if (Time.time >= ultimoAtaque + taxaDeAtaque)
         {
            int dano = Dano;

            DispararBomba(dano, enemiesInRange);
            
            ultimoAtaque = Time.time;
         }


        if (Time.time >= ultimoAtaque + taxaDeAtaque)
        {
            int dano = Dano;

            DispararBomba(dano, enemiesInRange);

            ultimoAtaque = Time.time;
        }

        if (Time.time >= ultimoAtaque + taxaDeAtaque)
        {
            int danoo = Dano;

            DispararBomba(Dano, enemiesInRange);

            ultimoAtaque = Time.time;
        }
    }


    
}
