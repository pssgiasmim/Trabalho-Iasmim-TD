using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : TowerBase
{
    //Método responsável por organizar informações de IceTower
    public void Start()
    {
        
    }

    //Método que faz a IceTower disparar duas bombas contra os inimigos.
    public override void Atacar(EnemyBase enemiesInRange)
    {
        if (Time.time >= ultimoAtaque + taxaDeAtaque)
        {
            int dano = Dano;
            if (enemiesInRange.tipoDeInimigo == "Fire")
            {
                dano *= 2;
            }
            Debug.Log("Atacando com duas bombas!");
            DispararBomba(dano, enemiesInRange);
            DispararBomba(dano, enemiesInRange);
            ultimoAtaque = Time.time;
        }
    }
}   
