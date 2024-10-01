using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : TowerBase
{
    //Método responsável por organizar informações de IceTower
    public void Start()
    {
        TaxaDeAtaque = 1.5f; //A taxa de ataque é de 1.5 float.
        Alcance = 4.0f; //O alcançe/distância é de 4.
        Dano = 8; //O valor do dano é de 8.
        TipoDeDano = "ice"; //O tipo de dano é gelo.
    }
}
