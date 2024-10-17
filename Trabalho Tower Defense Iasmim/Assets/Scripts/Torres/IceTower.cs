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
    public override void Atacar(GameObject alvo)
    {
        if (Time.time >= ultimoAtaque + taxaDeAtaque)
        {
            int dano = Dano;
            if (alvo.GetComponent<EnemyBase>().tipoDeInimigo == "Fire")
            {
                dano *= 2;
            }
            Debug.Log("Atacando com duas bombas!");
            DispararBomba(dano, alvo.GetComponent<EnemyBase>());
            DispararBomba(dano, alvo.GetComponent<EnemyBase>());
            ultimoAtaque = Time.time;
        }
    }
}   
