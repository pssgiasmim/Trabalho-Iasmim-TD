using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour, IAtacavel
{
    //Esta classe serve de base para todas as outras torres.

    public float TaxaDeAtaque; //Vari�vel da Taxa de ataque da torre.
    public float Alcance; //Vari�vel de Alcance da torre.
    public int Dano; //Vari�vel de Dano da torre.
    public string TipoDeDano; //Vari�vel do Tipo de dano da torre.
    private float UltimoAtaque; //Vari�vel que registra o �ltimo ataque da torre.

    //M�todo que tem como fun��o atacar os inimigos.
    public virtual void Atacar()
    {
        //Dentro dos scripts das torres especificas, estar� o detalhamento.
    }
}
