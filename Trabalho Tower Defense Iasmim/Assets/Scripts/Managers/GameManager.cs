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

    private int pontosDoJogador = 450;

    [SerializeField] TextMeshProUGUI pontosText;


    //Singleton, que permite que todas as coisas p�blicas da classe sejam acessadas por outra classe.
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    //M�todo que inicia o jogo.
    public void Start()
    {
        AtualizarUI();
    }

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

    //M�todo respons�vel por atualizar a UI conforme o pontos feitos pelo jogador.
    public void AtualizarUI()
    {
        if (pontosText != null)
        {
            pontosText.text = "Pontos: " + pontosDoJogador.ToString();
        }
    }

    //M�todo que � respons�vel por retornar os pontos do jogador.
    public int ObterPontos()
    {
        return pontosDoJogador;
    }

    //M�todo que desconta os pontos do jogador quando ele comprar as torres.
    public void DescontarPontos(int pontos)
    {
        pontosDoJogador -= pontos;
        AtualizarUI();
    }
}
