using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/*A classe GameManager, gerencia tudo o que tem dentro do jogo. 
  Como, uma lista de inimigos na cena. */

public class GameManager : MonoBehaviour
{
    
    public List<GameObject> enemies = new List<GameObject>(); //Lista dos inimigos que est�o no mapa.

    [SerializeField] EnemyDark enemyDark; //Vari�vel que ser� acrescentada na lista EnemyBase, que � o inimigo do escuro.
    [SerializeField] EnemyFire enemyFire; //Vari�vel que ser� acrescentada na lista EnemyBase, que � o inimigo de fogo.
    [SerializeField] EnemyIce enemyIce; //Vari�vel que ser� acrescentada na lista EnemyBase, que � o inimigo de gelo.
    [SerializeField] EnemyLight enemyLight; //Vari�vel que ser� acrescentada na lista EnemyBase, que � o inimigo de luz.
    [SerializeField] EnemyRock enemyRock; //Vari�vel que ser� acrescentada na lista EnemyBase, que � o inimigo de pedra.

    private int pontosDoJogador = 0;

    [SerializeField] TextMeshProUGUI pontosText;

    //Singleton, que permite que todas as coisas p�blicas da classe sejam acessadas por outra classe.
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion


    //Gerencia uma certa quantidade de inimigos na cena, n�o permintindo que passem de 10.
    public void GerenciarInimigo()
    {
        

        while (enemies.Count < 25)
        {
            SpawnManager.instance.Spawn();
            

           
        }
    }

    //M�todo que adiciona os inimigos na lista
    public void AdicionarInimigos(GameObject obj)
    {
        enemies.Add(obj);
        
    }

    //M�todo para fazer o jogador receber pontos para cada inimigo que ele matar.
    public void AdicionarPontos(int pontos)
    {
        pontosDoJogador += pontos;
        AtualizarUI();
    }

    public void AtualizarUI()
    {
        if (pontosText != null)
        {
            pontosText.text = "Pontos: " + pontosDoJogador.ToString();
        }
    }


}
