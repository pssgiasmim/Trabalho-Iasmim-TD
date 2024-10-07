using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject EnemyFire; //Vari�vel que armazena no inspector o EnemyFire.
    [SerializeField] GameObject EnemyIce; //Vari�vel que armazena no inspector o EnemyIce.
    [SerializeField] GameObject EnemyDark; //Vari�vel que armazena no inspector o EnemyDark.
    [SerializeField] GameObject EnemyLight; //Vari�vel que armazena no inspector o EnemyLight.
    [SerializeField] GameObject EnemyRock; //Vari�vel que armazena no inspector o EnemyRock                                        .
    float timer = 1.2f; //Vari�vel que � um timer para saber o momento certo de come�ar a instanciar.
    int TipoInimigo; //Vari�vel que tem um inimigo aleat�rio que servir� como condi��o para instanciar.


    //M�todo que vai Spawnar os inimigos na cena, em dire��o das torres.
    public void Spawn()
    {
        if (timer <= 0)
        {
            TipoInimigo = Random.Range(0, 100); //Valor aleat�rio entre 0 e 100 que instanciar� os inimigos.

            if (TipoInimigo > 50)
            {

            }
        }
    }
}
