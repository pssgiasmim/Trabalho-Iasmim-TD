using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Subclasse que representa LightTower e o seu m�todo de Ataque.
public class LightTower : TowerBase
{
    //M�todo inicia a classe
    public void Start()
    {
       
    }

    //M�todo que faz a LightTower disparar tr�s bombas contra os inimigos.
    public override void Atacar(GameObject alvo)
    {
        Debug.Log("Atacando com tr�s bombas.");
         if (Time.time >= ultimoAtaque + taxaDeAtaque)
         {
            int dano = Dano;

            DispararBomba(dano, alvo.GetComponent<EnemyBase>());
            
            ultimoAtaque = Time.time;
         }


        if (Time.time >= ultimoAtaque + taxaDeAtaque)
        {
            int dano = Dano;

            DispararBomba(dano, alvo.GetComponent<EnemyBase>());

            ultimoAtaque = Time.time;
        }

        if (Time.time >= ultimoAtaque + taxaDeAtaque)
        {
            int dano = Dano;

            DispararBomba(dano, alvo.GetComponent<EnemyBase>());

            ultimoAtaque = Time.time;
        }
    }


    
}
