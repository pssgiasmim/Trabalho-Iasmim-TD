using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLight : EnemyBase
{
    // M�todo de referencias das quest�es do inimigo de luz
    public void Start()
    {
        saude = 30; //quantidade de vidas do inimigo tipo luz.
        tipoDeInimigo = "luz"; //tipo do inimigo.
    }
    

    
}
