using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject EnemyFire; //Variável que armazena no inspector o EnemyFire.
    [SerializeField] GameObject EnemyIce; //Variável que armazena no inspector o EnemyIce.
    [SerializeField] GameObject EnemyDark; //Variável que armazena no inspector o EnemyDark.
    [SerializeField] GameObject EnemyLight; //Variável que armazena no inspector o EnemyLight.
    [SerializeField] GameObject EnemyRock; //Variável que armazena no inspector o EnemyRock                                        .
    float timer = 1.2f; //Variável que é um timer para saber o momento certo de começar a instanciar.
    int TipoInimigo; //Variável que tem um inimigo aleatório que servirá como condição para instanciar.


    //Método que vai Spawnar os inimigos na cena, em direção das torres.
    public void Spawn()
    {
        if (timer <= 0)
        {
            TipoInimigo = Random.Range(0, 100); //Valor aleatório entre 0 e 100 que instanciará os inimigos.

            if (TipoInimigo > 50)
            {

            }
        }
    }
}
