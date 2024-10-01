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

}
