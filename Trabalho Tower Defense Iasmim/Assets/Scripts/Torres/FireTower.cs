using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : TowerBase
{
   //M�todo respons�vel por organizar as informa��es da torre de fogo.
   public void Start()
   {
        
   }

    public override void Atacar(EnemyBase enemiesInRange)
    {
        if (Time.time >= ultimoAtaque + taxaDeAtaque)
        {
            int dano = Dano;
            if (enemiesInRange.tipoDeInimigo == "Dark")
            {
                dano *= 2;
            }
            Debug.Log("Atacando com uma bomba.");
            DispararBomba(dano, enemiesInRange);
            ultimoAtaque = Time.time;
        }
    }


}

