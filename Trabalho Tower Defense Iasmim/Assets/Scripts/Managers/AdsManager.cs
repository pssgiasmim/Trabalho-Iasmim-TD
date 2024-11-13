using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using static UnityEngine.Advertisements.Advertisement;

//Classe que gerencia as propagandas na cena do jogo.

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener,IUnityAdsShowListener
{
    public string projetoID = "5729648"; //ID do projeto;
    public string bannerID = "Banner_Android"; //ID do banner;
    public string interstitialIDSkip = "Interstitial_Android"; //ID do interstitial que pode pular;
    public string interstitialID = "Interstitial_DontSkip"; //ID do interstitial que N�O pode pular;
    public string rewardedID = "Rewarded_Android"; //ID da recompensa;

    private bool anuncioExibido = false; //Verifica s tem an�ncio sendo exibido;
    private int contadorInterstitial = 0; //Contador para alternar entre intersticiais pul�veis e n�o pul�veis
    private bool interstitialFechado = true; //Controla se o interstitial est� aberto ou fechado.

    public float tempoExibicaoBanner = 10f; //Tempo de exibi��o do banner na  tela;
    public float tempoEsconderBanner = 5f; //Tempo em que o banner fica escondido;
    private float timer = 0f; //Timer para controlar o tempo;
    private bool bannerVisivel = false; //Controla se o Banner est� aparecendo na tela;

    public delegate void DelegateDaRecompensa(int valor); //Delegate que cuida das recompensas do jogador
    public DelegateDaRecompensa AnuncioRecompensa; //Anuncio de recompensa do jogador

    //Singleton, que permite que todas as coisas p�blicas da classe sejam acessadas por outra classe.
    #region Singleton
    public static AdsManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion


    // Inicia tudo
    void Start()
    {
        Advertisement.Initialize(projetoID, true, this); //Inicia o Unity Ads, preparando o servi�o para exibir an�ncios no jogo;
        
    }

    //M�todo que � chamado a cada frame
    void Update()
    {
        if (anuncioExibido)  // N�o mostra o banner enquanto outro an�ncio estiver sendo exibido
        {
            return;
            
        }

        timer += Time.deltaTime;

        // L�gica para exibir e esconder o banner com base no tempo
        if (bannerVisivel)
        {
            if (timer >= tempoExibicaoBanner)
            {
                Advertisement.Banner.Hide(); // Esconde o banner depois de 10 segundos
                bannerVisivel = false;
                timer = 0f; // Reinicia o timer
            }
        }
        else
        {
            if (timer >= tempoEsconderBanner)
            {
                // Exibe o banner depois de 5 segundos
                Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER); //Configura o banner na posi��o superior da tela;
                Advertisement.Banner.Show("Banner_Android"); 
                bannerVisivel=true;
                timer = 0f; 
            }
        }
    }


    //M�todo que mostra a propaganda de recompensa;
    public void MostrarRewarded()
    {
        Advertisement.Banner.Hide();
        Advertisement.Show(rewardedID, this); 
    }

    //Mostra o banner num determinado tempo
    public void MostrarBanner()
    {
        if (!Advertisement.isInitialized || Advertisement.isShowing) return; //N�o mostrar o banner se outro an�ncio estiver sendo exibido;

        bannerVisivel = true;
        timer = 0f;
    }

    // Fun��o para mostrar o intersticial
    public void MostrarInterstitial()
    {
       if (interstitialFechado)
        {
            // Alterna entre os intersticiais pul�veis e n�o pul�veis
            if (contadorInterstitial % 2 == 0)
            {
                Advertisement.Show(interstitialIDSkip, this); // Exibe o intersticial que pode ser pulado
                Advertisement.Banner.Hide();
            }
            else
            {
                Advertisement.Show(interstitialID, this); // Exibe o intersticial que N�O pode ser pulado
                Advertisement.Banner.Hide();
            }

            // Inicia o contador e marca que o intersticial n�o foi fechado
            contadorInterstitial++;
            interstitialFechado = false;
        }
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        anuncioExibido = false;

        if (placementId == interstitialID || placementId == interstitialIDSkip )
        {
            // Caso o intersticial seja pulado ou finalizado normalmente
            interstitialFechado = true; // Marca o intersticial como fechado
            SpawnManager.instance.ContinuarSpawn(); //Chama a fun��o que continua a spawnar os inimigos.
        }


        if (placementId == rewardedID)
        {
            if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
            {
                Debug.Log("An�ncio completo! Recompensando jogador...");
                
                if (AnuncioRecompensa != null)
                {
                    AnuncioRecompensa(50); //O jogador recebe 50 pontos como recompensa
                }
                else
                {
                    Debug.Log("An�ncio n�o completado.");
                }
            }
        }
        //Para dar recompensa, o delegate pode ser criado dentro deste script, por�m deve armazenar os m�todos de fora.
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        interstitialFechado = true; // Aconteceu algum erro ao mostrar o an�ncio
        SpawnManager.instance.ContinuarSpawn(); // Chama a fun��o no SpawnManager para continuar o spawn
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        anuncioExibido = true;
    }
    public void OnInitializationComplete()
    {
        //N�o utilizar
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        //N�o utilizar
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        //N�o utilizar
    }

    

   
}
