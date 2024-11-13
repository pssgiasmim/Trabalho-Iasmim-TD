using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//A classe GameManager, gerencia tudo o que tem dentro do jogo. Como uma lista de inimigos, a tela de GameOver e os pontos que o jogador recebe e desconta.
public class GameManager : MonoBehaviour
{
    
    public List<GameObject> enemies = new List<GameObject>(); //Lista dos inimigos que est�o no mapa.

    private int pontosDoJogador = 110; //Vari�vel que armazena os pontos do jogador.

    public int inimigosQuePassaram = 0; //Vari�vel que � contador de quantos inimigos passaram pela torre.

    [SerializeField] TextMeshProUGUI pontosText; //Vari�vel do texto que apresenta os pontos na tela.
    [SerializeField] GameObject telaGameOver; //Vari�vel que referencia a tela de game over no inspector.
    [SerializeField] TextMeshProUGUI pontosFinaisText; //Vari�vel que armazena e apreenta os pontos finais do jogador.

    public Vector2 screenBounds; //Vari�vel que armazena os valores de scrrenbounds.

    public delegate void DelegateDaRecompensa(int valor); //Delegate para recompensar o jogador com pontos;
    public DelegateDaRecompensa valores; //Vari�vel baseada no delegate;



    //Singleton, que permite que todas as coisas p�blicas da classe sejam acessadas por outra classe.
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }
    #endregion



    //M�todo que inicia o jogo e garante que a tela de game over inicie desligada.
    public void Start()
    {
        AtualizarUI();
        telaGameOver.SetActive(false);

        //Inscreve no evento de recompensar o jogador
        if (AdsManager.instance != null)
        {
            AdsManager.instance.AnuncioRecompensa += AdicionarPontosDeRecompensa;
        }

    }

    public void Desinscrever() // Desinscreve do evento quando o GameManager for destru�do
    {
        if (AdsManager.instance != null)
        {
            AdsManager.instance.AnuncioRecompensa -= AdicionarPontosDeRecompensa;
        }
    }


    //M�todo respons�vel por atualizar a UI conforme o pontos feitos pelo jogador.
    public void AtualizarUI()
    {
        if (pontosText != null)
        {
            pontosText.text = "Pontos: " + pontosDoJogador.ToString();
        }
    }

    //M�todo para fazer o jogador receber pontos para cada inimigo que ele matar.
    public void AdicionarPontos(int pontos)
    {
        pontosDoJogador += pontos;
        AtualizarUI();
    }

    // M�todo que ser� chamado pelo AdsManager para adicionar pontos de recompensa
    public void AdicionarPontosDeRecompensa(int valor)
    {
        AdicionarPontos(valor); // Adiciona o valor que veio do AdsManager ao jogador
    }


    //M�todo que est� verificando toda hora de os inimigos passaram das torres.
    public void Update()
    {
        InimigoPassou();
    }



    //Gerencia uma certa quantidade de inimigos na cena, n�o permintindo que passem de 25.
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



    //M�todo chamado dentro de EnemyBase quando um inimigo passar das torres.
    public void InimigoPassou()
    {
                if (inimigosQuePassaram >= 20)
                {
                    GameOver();
                }
    }



    //M�todo respons�vel por exibir a tela de GameOver com a pontua��o final do jogador.
    public void GameOver()
    {
        telaGameOver.SetActive(true);
        pontosFinaisText.text = "Pontua��o Final: " + pontosDoJogador;
        Time.timeScale = 0;
    }



    //M�todo respons�vel por reiniciar o jogo.
    public void ReiniciarJogo()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
