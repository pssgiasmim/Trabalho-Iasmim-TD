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
    float tempoDeSpawn = 1.5f; //Temporizador para controlar o spawn dos grupos;
    int inimigosSpawnados = 0; //Contador de grupos que j� foram spawnados;
    int tamanhoDoGrupo = 10; //Quantidade de inimigos por grupo;
    int tipoInimigo; //Vari�vel que tem um inimigo aleat�rio que servir� como condi��o para instanciar.
    int spawnPlace; //Vari�vel que tem um valor aleat�rio  que ver� a posi��o de onde o inimigo ser� instanciado.
    float y; //Vari�veis que ir�o armazenar as posi��es. X � 7.85 e Y � aleat�rio.
    float tempoAtual = 0f; //Temporizador para controlar o spawn dentro do grupo
    private bool podeSpawnar = true; // Controla se pode spawnar novos inimigos ap�s o interstitial

    //Singleton, que permite que todas as coisas p�blicas da classe sejam acessadas por outra classe.
    #region Singleton
    public static SpawnManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    //M�todo que ativa o m�todo Spawn
    public void Update()
    {
        if (!podeSpawnar) return; // N�o permite spawnar at� que o intersticial seja fechado

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
                AdsManager.instance.MostrarInterstitial(); // Mostra o intersticial ap�s cada onda
                podeSpawnar = false; // Impede a pr�xima onda de aparecer at� o intersticial ser fechado
            }
        }
        
    }

    // M�todo para continuar o spawn ap�s o fechamento ou pulo do intersticial
    public void ContinuarSpawn()
    {
        podeSpawnar = true; // Permite spawnar o pr�ximo grupo de inimigos
    }

    //M�todo que vai Spawnar os inimigos na cena, em dire��o das torres.
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
