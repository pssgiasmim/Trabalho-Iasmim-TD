using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/* Está classe é responsável por spawnar os inimigos na direção das torres dentro do jogo.*/

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject EnemyFire; //Variável que armazena no inspector o EnemyFire.
    [SerializeField] GameObject EnemyIce; //Variável que armazena no inspector o EnemyIce.
    [SerializeField] GameObject EnemyDark; //Variável que armazena no inspector o EnemyDark.
    [SerializeField] GameObject EnemyLight; //Variável que armazena no inspector o EnemyLight.
    [SerializeField] GameObject EnemyRock; //Variável que armazena no inspector o EnemyRock                                        .
    float timer, initialTime = 1.2f; //Variável que é um timer para saber o momento certo de começar a instanciar.
    int tipoInimigo; //Variável que tem um inimigo aleatório que servirá como condição para instanciar.
    int spawnPlace; //Variável que tem um valor aleatório  que verá a posição de onde o inimigo será instanciado.
    float y; //Variáveis que irão armazenar as posições. X é 7.85 e Y é aleatório.

    //Singleton, que permite que todas as coisas públicas da classe sejam acessadas por outra classe.
    #region Singleton
    public static SpawnManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion



    //Método que vai Spawnar os inimigos na cena, em direção das torres.
    public void Spawn()
    {
        if (timer <= 0)
        {
            spawnPlace = Random.Range(1, 4); 

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

            tipoInimigo = Random.Range(0, 100); 

            if (tipoInimigo > 70) 
            {
                Instantiate(EnemyFire, new Vector3(7.85f, y, 0), Quaternion.identity); 
            }

            else if (tipoInimigo > 50) 
            {
                Instantiate(EnemyDark, new Vector3(7.85f, y, 0), Quaternion.identity); 
            }

            else if (tipoInimigo > 10) 
            {
                Instantiate(EnemyIce, new Vector3(7.85f, y, 0), Quaternion.identity); 
            }

            else if (tipoInimigo > 9) 
            {
                Instantiate(EnemyRock, new Vector3(7.85f, y, 0), Quaternion.identity); 
            }

            else if (tipoInimigo > 8) 
            {
                Instantiate(EnemyLight, new Vector3(7.85f, y, 0), Quaternion.identity); 
            }

            if (initialTime > 0.8f)
            {
                initialTime -= 0.05f;
            }

            timer = initialTime;

        }

        else
        {
            timer -= Time.deltaTime;
        }
    }

    //Método que ativa o método Spawn
    public void Update()
    {
        Spawn();
    }
}
