using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : TowerBase
{
    //M�todo respons�vel por organizar informa��es de IceTower
    public void Start()
    {
        TaxaDeAtaque = 1.5f; //A taxa de ataque � de 1.5 float.
        Alcance = 4.0f; //O alcan�e/dist�ncia � de 4.
        Dano = 8; //O valor do dano � de 8.
        TipoDeDano = "ice"; //O tipo de dano � gelo.
    }
}
