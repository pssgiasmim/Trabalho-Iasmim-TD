using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDark : EnemyBase
{
    //Método que referencia questões de inimigo escuro
    public void Start()
    {
        saude = 60; //quantidade de vida do inimigo do tipo escuro.
        tipoDeInimigo = "escuro"; //Tipo do inimigo.
    }

    //Método que ao inimigo DARK morrer, o jogador ganha 1 ponto.
    public override void Morrer()
    {
        GameManager.instance.AdicionarPontos(1);
        base.Morrer();
    }

}
