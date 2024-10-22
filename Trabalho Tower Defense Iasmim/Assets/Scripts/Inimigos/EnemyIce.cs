using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Subclasse que representa EnemyIce e o que ele faz ap�s ser destruido.
public class EnemyIce : EnemyBase
{
    //M�todo que referencia quest�es de inimigo gelo
    public void Start()
    {
        saude = 30; //A quantidade de vida do inimigo.
        tipoDeInimigo = "Ice"; //Tipode do inimigo.
    }

    //M�todo que ao inimigo ICE morrer, o jogador ganha 5 pontos.
    public override void Morrer()
    {
        GameManager.instance.AdicionarPontos(5);
        base.Morrer();
    }


}
