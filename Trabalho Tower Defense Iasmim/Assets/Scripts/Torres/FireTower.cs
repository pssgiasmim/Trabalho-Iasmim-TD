using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Subclasse que representa FireTower e o seu método de Ataque.
public class FireTower : TowerBase
{
   //Método responsável por organizar as informações da torre de fogo.
   public void Start()
   {
        
   }

    //Método que faz a FireTower disparar apenas uma bomba contra os inimigos.
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

