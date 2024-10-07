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
    int tipoInimigo; //Vari�vel que tem um inimigo aleat�rio que servir� como condi��o para instanciar.
    int spawnPlace; //Vari�vel que tem um valor aleat�rio  que ver� a posi��o de onde o inimigo ser� instanciado.
    float y; //Vari�veis que ir�o armazenar as posi��es. X � 7.85 e Y � aleat�rio.

    //M�todo que vai Spawnar os inimigos na cena, em dire��o das torres.
    public void Spawn()
    {
        if (timer <= 0)
        {
            spawnPlace = Random.Range(1, 4); //Valor aleat�rio entre 1 e 3 que "escolha" onde ser� instanciado os inimigos.

            if (spawnPlace == 1)
            {
                y = 2.89f;
            }

            else if (spawnPlace == 2)
            {
                y = -0.23f;
            }

            else if (spawnPlace == 3)
            {
                y = -3.27f;
            }

            tipoInimigo = Random.Range(0, 100); //Valor aleat�rio entre 0 e 100 que instanciar� os inimigos.

            if (tipoInimigo > 50)
            {

            }
        }
    }
}