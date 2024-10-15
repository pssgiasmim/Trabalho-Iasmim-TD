using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Define o comportamento de atacar, que pode ser usado pela torre ou inimigos
public interface IAtacavel 
{
    //Método atacar que faz com que algum objeto ataque outro, de acordo com o alcance.
    public void Atacar(EnemyBase enemiesInRange);

}
