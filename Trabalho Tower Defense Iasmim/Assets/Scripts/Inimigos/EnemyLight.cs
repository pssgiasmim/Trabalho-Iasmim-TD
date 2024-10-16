using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLight : EnemyBase
{
    // M�todo de referencias das quest�es do inimigo de luz
    public void Start()
    {
        saude = 20; //Quantidade de vida do inimigo.
        tipoDeInimigo = "Light"; //Tipo do inimigo.
    }

    //M�todo que ao inimigo LIGHT morrer, o jogador ganha 25 pontos
    public override void Morrer()
    {
        GameManager.instance.AdicionarPontos(25);
        base.Morrer();
    }



}
