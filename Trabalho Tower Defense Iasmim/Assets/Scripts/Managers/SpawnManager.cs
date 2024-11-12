using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/* Est� classe � respons�vel por spawnar os inimigos na dire��o das torres dentro do jogo.*/

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject EnemyFire; //Vari�vel que armazena no inspector o EnemyFire.
    [SerializeField] GameObject EnemyIce; //Vari�vel que armazena no inspector o EnemyIce.
    [SerializeField] GameObject EnemyDark; //Vari�vel que armazena no inspector o EnemyDark.
    [SerializeField] GameObject EnemyLight; //Vari�vel que armazena no inspector o EnemyLight.
    [SerializeField] GameObject EnemyRock; //Vari�vel que armazena no inspector o EnemyRock
                                           //.
    float timer = 10.0f; //Tempo entre os grupos de inimigos;
    float tempoDeSpawn = 0f; //Temporizador para controlar o spawn dos grupos;
    int inimigosSpawnados = 0; //Contador de grupos que j� foram spawnados;
    int tamanhoDoGrupo = 10; //Quantidade de inimigos por grupo;
    int tipoInimigo; //Vari�vel que tem um inimigo aleat�rio que servir� como condi��o para instanciar.
    int spawnPlace; //Vari�vel que tem um valor aleat�rio  que ver� a posi��o de onde o inimigo ser� instanciado.
    float y; //Vari�veis que ir�o armazenar as posi��es. X � 7.85 e Y � aleat�rio.

    //Singleton, que permite que todas as coisas p�blicas da classe sejam acessadas por outra classe.
    #region Singleton
    public static SpawnManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion



    //M�todo que vai Spawnar os inimigos na cena, em dire��o das torres.
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




    //M�todo que ativa o m�todo Spawn
    public void Update()
    {
        Spawn();
    }
}
