using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Subclasse que representa EnemyLight e o que ele faz ap�s ser destruido.
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
