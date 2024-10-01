using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAtacavel 
{
    //Define o comportamento de ataque ao inimigo

    //Método que ataca o inimigo
    public void Atacar(List<Enemy>enemiesInRange);

}
