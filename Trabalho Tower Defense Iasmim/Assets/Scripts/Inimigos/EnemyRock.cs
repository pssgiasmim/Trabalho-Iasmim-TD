using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRock : EnemyBase
{
    //Método que referencia questões de inimigo rocha.
    public void Start()
    {
        saude = 20; //A quantidade de vida do inimigo.
        tipoDeInimigo = "Rock"; //Tipo do inimigo.
    }

    //Método que ao inimigo ROCK morrer, o jogador ganha 15 pontos.
    public override void Morrer()
    {
        GameManager.instance.AdicionarPontos(15);
        base.Morrer();
    }



}
