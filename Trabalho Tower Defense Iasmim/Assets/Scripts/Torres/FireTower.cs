using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : TowerBase
{
   //M�todo respons�vel por organizar as informa��es da torre de fogo.
   public void Start()
   {
        TaxaDeAtaque = 1.0f; //A taxa de ataque � de 1 float.
        Alcance = 5.0f; //O alcance/ dist�ncia da torre � de 5 float.
        Dano = 10; //A valor do dano desta torre � de 10.
        TipoDeDano = "fire"; //O tipo de dano desta torre � fogo.
   }

    //Elabora��o do ataque da Torre de Fogo.
    public override void Atacar(List<EnemyBase>enemiesInRange)
    { 
        //Para cada inimigo em inimigoEmPerigo.
        foreach(EnemyBase enemy in enemiesInRange)
        {
            //Se o tipo do inimigo for igual a escuro.
            if (enemy.tipoDeInimigo == "escuro") //Esta torre s� ataca inimigos do tipo escuro.
            {
                //O inimigo "pega" o dano.
                enemy.ReceberDano(Dano);
            }

        }

    }

}
