using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDark : EnemyBase
{
    //M�todo que referencia quest�es de inimigo escuro
    public void Start()
    {
        saude = 60; //quantidade de vida do inimigo do tipo escuro.
        tipoDeInimigo = "escuro"; //Tipo do inimigo.
    }

    
}
