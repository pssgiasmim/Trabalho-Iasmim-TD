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
    [SerializeField] GameObject EnemyRock; //Variável que armazena no inspector o EnemyRock
                                           //.
    float timer = 10.0f; //Tempo entre os grupos de inimigos;
    float tempoDeSpawn = 0f; //Temporizador para controlar o spawn dos grupos;
    int inimigosSpawnados = 0; //Contador de grupos que já foram spawnados;
    int tamanhoDoGrupo = 10; //Quantidade de inimigos por grupo;
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
       if (tempoDeSpawn <= 0 && inimigosSpawnados < tamanhoDoGrupo) // Se o tempo estiver zerado e ainda houver inimigos para spawnar no grupo
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
                    GameObject obj = Instantiate(EnemyFire, new Vector3(7.85f, y, 0), Quaternion.identity);
                    GameManager.instance.AdicionarInimigos(obj);
            }

            else if (tipoInimigo > 50)
            {
                    GameObject obj = Instantiate(EnemyDark, new Vector3(7.85f, y, 0), Quaternion.identity);
                    GameManager.instance.AdicionarInimigos(obj);
            }

            else if (tipoInimigo > 10)
            {
                    GameObject obj = Instantiate(EnemyIce, new Vector3(7.85f, y, 0), Quaternion.identity);
                    GameManager.instance.AdicionarInimigos(obj);
            }

            else if (tipoInimigo > 9)
            {
                    GameObject obj = Instantiate(EnemyRock, new Vector3(7.85f, y, 0), Quaternion.identity);
                    GameManager.instance.AdicionarInimigos(obj);
            }

            else if (tipoInimigo > 8)
            {
                    GameObject obj = Instantiate(EnemyLight, new Vector3(7.85f, y, 0), Quaternion.identity);
                    GameManager.instance.AdicionarInimigos(obj);
            }

            inimigosSpawnados++; //Amenta o contador de inimigos spawnados;
            tempoDeSpawn = 1.0f; //Tempo entre cada spawn de inimigo;

            if (inimigosSpawnados >= tamanhoDoGrupo) // Quando 10 inimigos forem spawnados, reinicia o grupo
            {
                inimigosSpawnados = 0;

                tempoDeSpawn = 10f; //Tempo de spawn de cada grupo;
                
                if (tempoDeSpawn > 0) //reduz o tempo de espera entyre os spawns;
                {
                    tempoDeSpawn  -= Time.deltaTime;
                }
            }
       } 

    }




    //Método que ativa o método Spawn
    public void Update()
    {
        Spawn();
    }
}
