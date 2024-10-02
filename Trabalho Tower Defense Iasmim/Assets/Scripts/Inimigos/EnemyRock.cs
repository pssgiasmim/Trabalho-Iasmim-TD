using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRock : EnemyBase
{
    //Método que referencia questões de inimigo rocha.
    public void Start()
    {
        saude = 80; //quantidade de vidas de inimigo rocha.
        tipoDeInimigo = "rocha"; //tipo do inimigo.
    }
    

    
}
