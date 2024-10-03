using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : TowerBase
{
   //Método responsável por organizar as informações da torre de fogo.
   public void Start()
   {
        TaxaDeAtaque = 1.0f; //A taxa de ataque é de 1 float.
        Alcance = 5.0f; //O alcance/ distância da torre é de 5 float.
        Dano = 10; //A valor do dano desta torre é de 10.
        TipoDeDano = "fire"; //O tipo de dano desta torre é fogo.
   }

    //Elaboração do ataque da Torre de Fogo.
    public override void Atacar(List<EnemyBase>enemiesInRange)
    { 
        //Para cada inimigo em inimigoEmPerigo.
        foreach(EnemyBase enemy in enemiesInRange)
        {
            //Se o tipo do inimigo for igual a escuro.
            if (enemy.tipoDeInimigo == "escuro") //Esta torre só ataca inimigos do tipo escuro.
            {
                //O inimigo "pega" o dano.
                enemy.ReceberDano(Dano);
            }

        }

    }

}
