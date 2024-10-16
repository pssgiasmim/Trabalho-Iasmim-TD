using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLight : EnemyBase
{
    // Método de referencias das questões do inimigo de luz
    public void Start()
    {
        saude = 20; //Quantidade de vida do inimigo.
        tipoDeInimigo = "Light"; //Tipo do inimigo.
    }

    //Método que ao inimigo LIGHT morrer, o jogador ganha 25 pontos
    public override void Morrer()
    {
        GameManager.instance.AdicionarPontos(25);
        base.Morrer();
    }



}
