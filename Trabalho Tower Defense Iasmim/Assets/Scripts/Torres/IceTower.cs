using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : TowerBase
{
    //M�todo respons�vel por organizar informa��es de IceTower
    public void Start()
    {
        
    }

    //M�todo que faz a IceTower disparar duas bombas contra os inimigos.
    public override void Atacar(EnemyBase enemiesInRange)
    {
        if (Time.time >= UltimoAtaque + TaxaDeAtaque)
        {
            int dano = Dano;
            if (enemiesInRange.tipoDeInimigo == "Fire")
            {
                dano *= 2;
            }
            Debug.Log("Atacando com duas bombas!");
            DispararBomba(dano, enemiesInRange);
            DispararBomba(dano, enemiesInRange);
            UltimoAtaque = Time.time;
        }
    }
}   
