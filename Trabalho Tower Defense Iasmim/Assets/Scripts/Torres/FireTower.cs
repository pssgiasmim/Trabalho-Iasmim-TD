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

}
