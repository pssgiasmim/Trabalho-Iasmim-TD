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
    [SerializeField] GameObject EnemyRock; //Vari�vel que armazena no inspector o EnemyRock                                        .
    float timer = 3.0f; //Vari�vel que � um timer para saber o momento certo de come�ar a instanciar.
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
        if (timer <= 0)
        {
            timer = 1.0f;

            if (GameManager.instance.enemies.Count < 25)
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

                
            }

        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
        


    }




    //M�todo que ativa o m�todo Spawn
    public void Update()
    {
        Spawn();
    }
}
