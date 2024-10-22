using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Subclasse que representa FireTower e o seu m�todo de Ataque.
public class FireTower : TowerBase
{
   //M�todo respons�vel por organizar as informa��es da torre de fogo.
   public void Start()
   {
        
   }

    //M�todo que faz a FireTower disparar apenas uma bomba contra os inimigos.
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

