using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : TowerBase
{
    //M�todo respons�vel por organizar informa��es de IceTower
    public void Start()
    {
        
    }

    /*/Elabora��o do ataque da Torre de Gelo
    public override void Atacar(List<EnemyBase> enemiesInRange)
    {
        //Para cada Inimigo em inimigoEmPerigo
        foreach (EnemyBase enemy in enemiesInRange)
        {
            //Se o tipo do inimigo for igual a fogo
            if (enemy.tipoDeInimigo == "fogo") //Esta torre s� ataca inimigos do tipo fogo.
            {
                //O inimigo "pega" o dano.
                enemy.ReceberDano(Dano);
            }
        }
    }*/
}   
