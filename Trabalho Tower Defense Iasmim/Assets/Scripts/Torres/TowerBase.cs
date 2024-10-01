using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour, IAtacavel
{
    //Esta classe serve de base para todas as outras torres.

    public float TaxaDeAtaque; //Variável da Taxa de ataque da torre.
    public float Alcance; //Variável de Alcance da torre.
    public int Dano; //Variável de Dano da torre.
    public string TipoDeDano; //Variável do Tipo de dano da torre.
    private float UltimoAtaque; //Variável que registra o último ataque da torre.


}
