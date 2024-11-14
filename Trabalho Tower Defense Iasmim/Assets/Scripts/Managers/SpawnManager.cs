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
    float tempoDeSpawn = 1.5f; //Temporizador para controlar o spawn dos grupos;
    int inimigosSpawnados = 0; //Contador de grupos que já foram spawnados;
    int tamanhoDoGrupo = 10; //Quantidade de inimigos por grupo;
    int tipoInimigo; //Variável que tem um inimigo aleatório que servirá como condição para instanciar.
    int spawnPlace; //Variável que tem um valor aleatório  que verá a posição de onde o inimigo será instanciado.
    float y; //Variáveis que irão armazenar as posições. X é 7.85 e Y é aleatório.
    float tempoAtual = 0f; //Temporizador para controlar o spawn dentro do grupo
    private bool podeSpawnar = true; // Controla se pode spawnar novos inimigos após o interstitial

    //Singleton, que permite que todas as coisas públicas da classe sejam acessadas por outra classe.
    #region Singleton
    public static SpawnManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    //Método que ativa o método Spawn
    public void Update()
    {
        if (!podeSpawnar) return; // Não permite spawnar até que o intersticial seja fechado

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        else
        {
            tempoAtual -= Time.deltaTime;

            if (tempoAtual <= 0)
            {
                Spawn();
                tempoAtual = tempoDeSpawn;
            }
            

            if (inimigosSpawnados >= tamanhoDoGrupo)
            {
                inimigosSpawnados = 0;
                timer = 10.0f;
                AdsManager.instance.MostrarInterstitial(); // Mostra o intersticial após cada onda
                podeSpawnar = false; // Impede a próxima onda de aparecer até o intersticial ser fechado
            }
        }
        
    }

    // Método para continuar o spawn após o fechamento ou pulo do intersticial
    public void ContinuarSpawn()
    {
        podeSpawnar = true; // Permite spawnar o próximo grupo de inimigos
    }

    //Método que vai Spawnar os inimigos na cena, em direção das torres.
    public void Spawn()
    {
       if (inimigosSpawnados < tamanhoDoGrupo) // Se o tempo estiver zerado e ainda houver inimigos para spawnar no grupo
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
            timer = tempoDeSpawn; //Tempo entre cada spawn de inimigo;

       } 

      


    }




    
}
