using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRock : EnemyBase
{
    //M�todo que referencia quest�es de inimigo rocha.
    public void Start()
    {
        saude = 20; //A quantidade de vida do inimigo.
        tipoDeInimigo = "Rock"; //Tipo do inimigo.
    }

    //M�todo que ao inimigo ROCK morrer, o jogador ganha 15 pontos.
    public override void Morrer()
    {
        GameManager.instance.AdicionarPontos(15);
        base.Morrer();
    }



}
