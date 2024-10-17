using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : TowerBase
{
   //Método responsável por organizar as informações da torre de fogo.
   public void Start()
   {
        
   }

    public override void Atacar(GameObject alvo)
    {
        if (Time.time >= ultimoAtaque + taxaDeAtaque)
        {
            int dano = Dano;
            if (alvo.GetComponent<EnemyBase>().tipoDeInimigo == "Dark")
            {
                dano *= 2;
            }
            Debug.Log("Atacando com uma bomba.");
            DispararBomba(dano, alvo.GetComponent<EnemyBase>());
            ultimoAtaque = Time.time;
        }
    }


}

