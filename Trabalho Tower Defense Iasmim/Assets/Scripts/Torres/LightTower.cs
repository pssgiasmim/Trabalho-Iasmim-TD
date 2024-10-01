using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTower : TowerBase
{
    //Método responsável por organizar informações de LightTower
    public void Start()
    {
        TaxaDeAtaque = 0.5f; //A taxa de ataque é de 0.5f
        Alcance = 6.0f; //O alcance/distância é de 6f
        Dano = 15; //O valor do dano é 15
        TipoDeDano = "light"; //O tipo de dano é luz
    }

    //Elaboração do ataque da Torre de Luz
    public override void Atacar(List<Enemy>enemiesInRange)
    {
        //Para cada Inimigo em inimigoEmPerigo
        foreach(Enemy enemy in enemiesInRange)
        {
            //Aqui ataca todos os inimigos.
            enemy.PegarDano(Dano);
        }
    }

}
