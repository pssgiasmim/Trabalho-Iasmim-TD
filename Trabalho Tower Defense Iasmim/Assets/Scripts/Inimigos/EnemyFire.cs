using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : EnemyBase
{
    //M�todo que referencias quest�es do Inimigo Fogo
    public void Start()
    {
        saude = 50; //Quantidade de vida 
        tipoDeInimigo = "Fire"; //Tipo do inimigo 
    }

    //M�todo que ao inimigo FIRE morrer, o jogador ganha 10 pontos
    public override void Morrer()
    {
        GameManager.instance.AdicionarPontos(10);
        base.Morrer(); 
    }
        
    

    
}
