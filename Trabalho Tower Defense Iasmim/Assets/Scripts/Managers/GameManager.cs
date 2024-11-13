using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//A classe GameManager, gerencia tudo o que tem dentro do jogo. Como uma lista de inimigos, a tela de GameOver e os pontos que o jogador recebe e desconta.
public class GameManager : MonoBehaviour
{
    
    public List<GameObject> enemies = new List<GameObject>(); //Lista dos inimigos que estão no mapa.

    private int pontosDoJogador = 110; //Variável que armazena os pontos do jogador.

    public int inimigosQuePassaram = 0; //Variável que é contador de quantos inimigos passaram pela torre.

    [SerializeField] TextMeshProUGUI pontosText; //Variável do texto que apresenta os pontos na tela.
    [SerializeField] GameObject telaGameOver; //Variável que referencia a tela de game over no inspector.
    [SerializeField] TextMeshProUGUI pontosFinaisText; //Variável que armazena e apreenta os pontos finais do jogador.

    public Vector2 screenBounds; //Variável que armazena os valores de scrrenbounds.

    public delegate void DelegateDaRecompensa(int valor); //Delegate para recompensar o jogador com pontos;
    public DelegateDaRecompensa valores; //Variável baseada no delegate;



    //Singleton, que permite que todas as coisas públicas da classe sejam acessadas por outra classe.
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }
    #endregion



    //Método que inicia o jogo e garante que a tela de game over inicie desligada.
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

    public void Desinscrever() // Desinscreve do evento quando o GameManager for destruído
    {
        if (AdsManager.instance != null)
        {
            AdsManager.instance.AnuncioRecompensa -= AdicionarPontosDeRecompensa;
        }
    }


    //Método responsável por atualizar a UI conforme o pontos feitos pelo jogador.
    public void AtualizarUI()
    {
        if (pontosText != null)
        {
            pontosText.text = "Pontos: " + pontosDoJogador.ToString();
        }
    }

    //Método para fazer o jogador receber pontos para cada inimigo que ele matar.
    public void AdicionarPontos(int pontos)
    {
        pontosDoJogador += pontos;
        AtualizarUI();
    }

    // Método que será chamado pelo AdsManager para adicionar pontos de recompensa
    public void AdicionarPontosDeRecompensa(int valor)
    {
        AdicionarPontos(valor); // Adiciona o valor que veio do AdsManager ao jogador
    }


    //Método que está verificando toda hora de os inimigos passaram das torres.
    public void Update()
    {
        InimigoPassou();
    }



    //Gerencia uma certa quantidade de inimigos na cena, não permintindo que passem de 25.
    public void GerenciarInimigo()
    {
        while (enemies.Count < 25)
        {
            SpawnManager.instance.Spawn();
        }
    }



    //Método que adiciona os inimigos na lista
    public void AdicionarInimigos(GameObject obj)
    {
        enemies.Add(obj);
        
    }



    //Método que é responsável por retornar os pontos do jogador.
    public int ObterPontos()
    {
        return pontosDoJogador;
    }



    //Método que desconta os pontos do jogador quando ele comprar as torres.
    public void DescontarPontos(int pontos)
    {
        pontosDoJogador -= pontos;
        AtualizarUI();
    }



    //Método chamado dentro de EnemyBase quando um inimigo passar das torres.
    public void InimigoPassou()
    {
                if (inimigosQuePassaram >= 20)
                {
                    GameOver();
                }
    }



    //Método responsável por exibir a tela de GameOver com a pontuação final do jogador.
    public void GameOver()
    {
        telaGameOver.SetActive(true);
        pontosFinaisText.text = "Pontuação Final: " + pontosDoJogador;
        Time.timeScale = 0;
    }



    //Método responsável por reiniciar o jogo.
    public void ReiniciarJogo()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
